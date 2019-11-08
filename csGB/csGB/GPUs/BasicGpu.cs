using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace csGB.GPUs
{
    public class BasicGpu : IGPU
    {
        int[] buffer = new int[160 * 128];

        int clock;

        // other registers that aren't explicitly referenced
        int[] reg = new int[0xBF];

        /// <summary>
        /// LCD Control Register
        /// </summary>
        /// <remarks>0xFF40</remarks>
        private int LCDC;

        /// <summary>
        /// LCD Status Register
        /// </summary>
        /// <remarks>0xFF41</remarks>
        private int STAT;

        /// <summary>
        /// Y Scroll
        /// </summary>
        /// <remarks>0xFF42</remarks>
        private int SCY;

        /// <summary>
        /// X Scroll
        /// </summary>
        /// <remarks>0xFF43</remarks>
        private int SCX;

        /// <summary>
        /// Y scroll line
        /// </summary>
        /// <remarks>0xFF44</remarks>
        private int LY;

        /// <summary>
        /// Y scroll line compare - if LY = LYC, trigger interrupt
        /// </summary>
        /// <remarks>0xFF45</remarks>
        private int LYC;

        public int ReadByte(int addr)
        {
            var gaddr = addr - 0xFF40;
            switch (gaddr)
            {
                case 0:
                    return LCDC;

                case 1:
                    return STAT;

                case 2:
                    return SCY;

                case 3:
                    return SCX;

                case 4:
                    return LY;

                case 5:
                    return LYC;

                default:
                    return reg[gaddr];
            }
        }

        public void WriteByte(int addr, int val)
        {
            var gaddr = addr - 0xFF40;
            reg[gaddr] = val;
            switch (gaddr)
            {
                case 0:
                    LCDC = val;
                    break;

                case 2:
                    SCY = val;
                    break;

                case 3:
                    SCX = val;
                    break;
                
                case 5:
                    LYC = val;
                    break;

                default:
                    reg[gaddr] = val;
                    break;
            }
        }

        public void Step()
        {
            // complete screen refresh occurs every 70224 clocks
            clock++;

            if (clock == 70224)
            {
                clock = 0;
                RenderScreen();
            }
        }

        private void RenderScreen()
        {
            GetData();

            for (int i = 0; i < 160; i++)
            {
                // set the current line
                LY = i;

                RenderLine();
            }
        }

        private void GetData()
        {
            for(int i = 0; i < 32*32; i++)
            {
                bgMapLower[i] = MMU.rb(i + 0x9800);
                bgMapHigher[i] = MMU.rb(i + 0x9C00);
            }

            int[] tileBuffer = new int[16];
            for (int i = 0; i < 384; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    tileBuffer[j] = MMU.rb(16 * i + j + 0x8000);
                }

                tiles[i] = new Tile(tileBuffer);
            }

            bgPalette = new Palette(MMU.rb(0xFF47));
            sprite0Palette = new Palette(MMU.rb(0xFF48));
            sprite1Palette = new Palette(MMU.rb(0xFF49));
        }

        private Palette bgPalette;
        private Palette sprite0Palette;
        private Palette sprite1Palette;

        // $8000 => $97FF
        private readonly Tile[] tiles = new Tile[384];

        // $9800 => $9BFF, $9C00 => $9FFF
        public readonly int[] bgMapLower = new int[32 * 32];
        public readonly int[] bgMapHigher = new int[32 * 32];

        /// <summary>
        /// vram sprite attribute table (OAM)
        /// </summary>
        /// <remarks>
        /// $FE00-FE9F
        /// Each entry is 4 bytes:
        ///   0: Y-Pos,
        ///   1: X-Pos,
        ///   2: Tile/Pattern No.
        ///   3: Attributes
        ///        7: Obj/BG priority (0=obj above bg, 1=obj behind bg, except if BG color is 0)
        ///        6: Y-Flip
        ///        5: X-Flip
        ///        4: Palette number (0=OBP0, 1=OBP1)
        ///        3-0: not in use
        /// </remarks>
        public int[] OAM { get; private set; } = new int[160];

        /// <summary>
        /// VRAM Tile Data
        /// </summary>
        /// <remarks>
        /// $8000 => $97FF - Tile Data
        /// $9800 => $9FFF - Background Maps
        /// </remarks>
        public int[] VRAM { get; private set; } = new int[8192];

        public int[] REG => reg;

        public Action<byte[]> DrawScreenCallback { get; set; }

        private void RenderLine()
        {
            LoadPallette();
            var line = LY;

            // ignore screen/bg scrolling for now.
            RenderBgLine();

            // todo: render sprite line

            LY++;

            if (LY == 128)
                LY = 0;
        }

        private void RenderBgLine()
        {
            LoadTiles();

            var bufferLine = new ArraySpan<int>(buffer, LY * 160, 160);

            var bgMap = (LCDC & (1 << 3)) == 0 ? bgMapLower : bgMapHigher ; // 0 - $9800-$9BFF, 1 - $9C00-$9FFF : 1024 addresses (32 x 32)

            var bgMode = (LCDC & (1 << 4)); // 0 - $8800-$97FF, 1 - $8000-$8FFF : 4095 addresses, 256 different tiles at 16 bytes each
            LOG.@out(nameof(BasicGpu), $"BGMode: {(bgMode == 0 ? 0 : 1)}");

            var line = LY;
            LOG.@out(nameof(BasicGpu), $"Drawing BG Line for line: {line}");

            // loop through the tiles - 32 tiles per row, but only need first 20 tiles to complete a row
            for (int tileX = 0; tileX < 20; tileX++)
            {
                var tileY = LY / 8;
                var bgLineOffset = tileY * 32;

                // get the bgTileMap
                var bgTileIndex = bgMap[tileX + bgLineOffset];

                LOG.@out(nameof(BasicGpu), $"Fetching tile info for tile: {tileX},{tileY}");

                // get the tile id
                Tile bgTile;

                // get the address of the tile that we're after
                if (bgMode == 0)
                {
                    // banks 0 (0 => 127) and 1 (128 => 255)
                    var index = (bgTileIndex + 128) % 256;

                    LOG.@out(nameof(BasicGpu), $"Getting Tile {index}");

                    bgTile = tiles[index];
                }
                else
                {
                    // signed - -128 to 127
                    // banks 1 (128 => 255) and 2 (256 => 384)
                    var index = bgTileIndex + 128;

                    LOG.@out(nameof(BasicGpu), $"Getting Tile {index}");

                    bgTile = tiles[index];
                }

                var tilePixelRow = LY % 8;
                LOG.@out(nameof(BasicGpu), $"Using line: {tilePixelRow} of tile");

                for (int tilePixel = 0; tilePixel < 8; tilePixel++)
                {
                    // draw the 8 pixels of the tile
                    var pixel = bgTile.pixels[tilePixel, tilePixelRow];

                    // get the color palette to use
                    var pixelShade = bgPalette[pixel];
                    LOG.@out(nameof(BasicGpu), $"Pixel {tilePixel} - value: {pixel}, palette: {pixelShade}");

                    // just straight up assign it
                    bufferLine[tilePixel + tileX * 8] = pixelShade;
                }
            }
        }

        public void Reset()
        {
            VRAM = new int[8192];
            OAM = new int[160];

            for (int i = 0; i < 4; i++)
            {
                bgPalette[i] = 255;
                //palette.obj0[i] = 255;
                //palette.obj1[i] = 255;
            }

            for (int i = 0; i < tiles.Length; i++)
                tiles[i].Reset();

            LOG.@out("GPU", "Initialising screen.");

            LY = 0;
            LYC = 0;

            // Set to values expected by BIOS, to start
            //_bgtilebase = 0x0000;
            //_bgmapbase = 0x1800;
            //_wintilebase = 0x1800;

            LOG.@out("GPU", "Reset.");
        }

        public void DrawScreen()
        {
            for (int i = 0; i < 128; i++)
            {
                RenderLine();
            }

            BitmapData buflock = canvas.LockBits(
                new Rectangle(Point.Empty, canvas.Size),
                ImageLockMode.WriteOnly, 
                PixelFormat.Format8bppIndexed);

            unsafe
            {
                // get the pointer address for the source buffer
                GCHandle pinnedArray = GCHandle.Alloc(buffer, GCHandleType.Pinned);

                int* bufferPointer = (int*)pinnedArray.AddrOfPinnedObject();
                
                Byte* bufdata = (Byte*)buflock.Scan0;
                
                // copy the data from source buffer to destination, converting from an int to a byte;
                for (int i = 0; i < 160*128; i++)
                {
                    *(bufdata + i) = (byte)*(bufferPointer + i);
                }
            }

            canvas.UnlockBits(buflock);
        }

        Bitmap canvas;

        public Bitmap InitializeScreen()
        {
            var bmp = new Bitmap(160, 128, PixelFormat.Format8bppIndexed);

            var pal = bmp.Palette;

            pal.Entries[0] = Color.Black;
            pal.Entries[1] = Color.FromArgb(85, 85, 85);
            pal.Entries[2] = Color.FromArgb(130, 130, 130);
            pal.Entries[3] = Color.White;

            bmp.Palette = pal;

            this.canvas = bmp;

            return bmp;
        }

        private void LoadTiles()
        {
            var tileBuffer = new int[16];
            for (int i = 0; i < tiles.Length; i++)
            {
                Array.Copy(VRAM, i * 16, tileBuffer, 0, 16);
                tiles[i] = new Tile(tileBuffer);
            }
        }

        private void LoadPallette()
        {
            var paletteData = ReadByte(0xFF47);
            LOG.@out(nameof(BasicGpu), $"Raw palette data: 0b{Convert.ToString(paletteData, 2).PadLeft(8, '0')}");

            bgPalette = new Palette(paletteData);
        }
    }
}
