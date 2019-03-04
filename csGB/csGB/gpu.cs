using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csGB
{
    class GPU
    {
        public static int[] _vram { get; set; } = new int[8192];
        public static int[] _oam { get; set; } = new int[160];
        public static int[] _reg { get; set; } = new int[10];
        public static int[,,] _tilemap { get; set; } = new int[512, 8, 8];

        public static ObjData[] _objdata { get; set; } = new ObjData[40];
        public static ObjData[] _objdatasorted { get; set; } = _objdata.ToArray(); // we want to initialise this with the same instances of objects as in _objdata

        public static int[,] _canvas { get; set; } = new int[160, 144];

        public static class _palette
        {
            public static int[] bg = new int[4];
            public static int[] obj0 = new int[4];
            public static int[] obj1 = new int[4];
        }

        public static class _scrn
        {
            public static int width { get; set; } = 160;
            public static int height { get; set; } = 144;
            public static int[] data { get; set; } = new int[width * height];
        }

        public class ObjData
        {
            public int y { get; set; } = -16; // starts hidden
            public int x { get; set; } = -8;
            public int tile { get; set; } = 0;
            public int palette { get; set; } = 0;
            public int yflip { get; set; } = 0;
            public int xflip { get; set; } = 0;
            public int prio { get; set; } = 0;
            public int num { get; set; } = 0;
        }

        public static int[] _scanrow { get; set; } = new int[160];

        public static int _curline = 0;
        public static int _curscan = 0;
        public static int _linemode = 0;
        public static int _modeclocks = 0;

        public static int _yscrl = 0;
        public static int _xscrl = 0;
        public static int _raster = 0;
        public static int _ints = 0;
  
        public static int _lcdon = 0;
        public static int _bgon = 0;
        public static int _objon = 0;
        public static int _winon = 0;

        public static int _objsize = 0;

        public static int _bgtilebase = 0x0000;
        public static int _bgmapbase = 0x1800;
        public static int _wintilebase = 0x1800;

        public static void reset()
        {
            GPU._vram = new int[8192];
            GPU._oam = new int[160];

            for (int i = 0; i < 4; i++)
            {
                GPU._palette.bg[i] = 255;
                GPU._palette.obj0[i] = 255;
                GPU._palette.obj1[i] = 255;
            }

            GPU._tilemap = new int[512, 8, 8];

            LOG.@out("GPU", "Initialising screen.");
            
            GPU._canvas = new int[160, 144];
            for (int i = 0; i < GPU._scrn.data.Length; i++)
                GPU._scrn.data[i] = 255;

            CopyScrnToCanvas();

            GPU._curline = 0;
            GPU._curscan = 0;
            GPU._linemode = 2;
            GPU._modeclocks = 0;
            GPU._yscrl = 0;
            GPU._xscrl = 0;
            GPU._raster = 0;
            GPU._ints = 0;

            GPU._lcdon = 0;
            GPU._bgon = 0;
            GPU._objon = 0;
            GPU._winon = 0;

            GPU._objsize = 0;
                GPU._scanrow = new int[160];

            for (int i = 0; i < 40; i++)
            {
                GPU._objdata[i] = new ObjData
                {
                    y = -16,
                    x = -8,
                    tile = 0,
                    palette = 0,
                    yflip = 0,
                    xflip = 0,
                    prio = 0,
                    num = i
                };
            }

            // Set to values expected by BIOS, to start
            GPU._bgtilebase = 0x0000;
            GPU._bgmapbase = 0x1800;
            GPU._wintilebase = 0x1800;

            LOG.@out("GPU", "Reset.");
        }

        public static void checkline()
        {
            // GPU State Machine

            GPU._modeclocks += Z80._r.m;
            switch (GPU._linemode)
            {
                // In hblank
                case 0:
                    if (GPU._modeclocks >= 51)
                    {
                        // End of hblank for last scanline; render screen
                        if (GPU._curline == 143)
                        {
                            GPU._linemode = 1;
                            CopyScrnToCanvas(); //GPU._canvas.putImageData(GPU._scrn, 0, 0);
                            MMU._if |= 1;
                        }
                        else
                        {
                            GPU._linemode = 2;
                        }
                        GPU._curline++;
                        GPU._curscan += 160; // we're only using a single int, not 4 ints, to represent each pixel
                        GPU._modeclocks = 0;
                    }
                    break;

                // In vblank
                case 1:
                    if (GPU._modeclocks >= 114)
                    {
                        GPU._modeclocks = 0;
                        GPU._curline++;
                        if (GPU._curline > 153)
                        {
                            GPU._curline = 0;
                            GPU._curscan = 0;
                            GPU._linemode = 2;
                        }
                    }
                    break;

                // In OAM-read mode
                case 2:
                    if (GPU._modeclocks >= 20)
                    {
                        GPU._modeclocks = 0;
                        GPU._linemode = 3;
                    }
                    break;

                // In VRAM-read mode
                case 3:
                    RenderLine();
                    break;
            }
        }

        public static void RenderLine()
        {
            // Render scanline at end of allotted time
            if (GPU._modeclocks >= 43)
            {
                GPU._modeclocks = 0;
                GPU._linemode = 0;
                if (GPU._lcdon != 0)
                {
                    RenderTiles();
                    RenderSprites();
                }
                else
                {
                    // else - clear line in buffer?
                }
            }
        }

        public static void RenderTiles()
        {
            if (GPU._bgon != 0)
            {
                var linebase = GPU._curscan;
                var mapbase = GPU._bgmapbase + ((((GPU._curline + GPU._yscrl) & 255) >> 3) << 5);
                var y = (GPU._curline + GPU._yscrl) & 7;
                var x = GPU._xscrl & 7;
                var t = (GPU._xscrl >> 3) & 31;
                var w = 160;

                var tilerow = new { x = 0, y = 0 };

                if (GPU._bgtilebase != 0)
                {
                    var tile = GPU._vram[mapbase + t];
                    if (tile < 128) tile = 256 + tile;
                    tilerow = new { x = tile, y };
                    do
                    {
                        GPU._scanrow[160 - x] = GPU._tilemap[tilerow.x, tilerow.y, x];
                        GPU._scrn.data[linebase + 3] = GPU._palette.bg[GPU._tilemap[tilerow.x, tilerow.y, x]];
                        x++;
                        if (x == 8) { t = (t + 1) & 31; x = 0; tile = GPU._vram[mapbase + t]; if (tile < 128) tile = 256 + tile; tilerow = new { x = tile, y }; }
                        linebase += 4;
                    } while (--w > 0);
                }
                else
                {
                    tilerow = new { x = GPU._vram[mapbase + t], y };
                    do
                    {
                        GPU._scanrow[160 - x] = GPU._tilemap[tilerow.x, tilerow.y, x];
                        GPU._scrn.data[linebase + 3] = GPU._palette.bg[GPU._tilemap[tilerow.x, tilerow.y, x]];
                        x++;
                        if (x == 8) { t = (t + 1) & 31; x = 0; tilerow = new { x = GPU._vram[mapbase + t], y }; }
                        linebase += 4;
                    } while (--w > 0);
                }
            }
        }

        public static void RenderSprites()
        {
            if (GPU._objon != 0)
            {
                var cnt = 0;
                if (GPU._objsize != 0)
                {
                    for (var i = 0; i < 40; i++)
                    {
                    }
                }
                else
                {
                    var tilerow = new { x = 0, y = 0 };
                    ObjData obj;
                    int[] pal;
                    int x;
                    var linebase = GPU._curscan;
                    for (var i = 0; i < 40; i++)
                    {
                        obj = GPU._objdatasorted[i];
                        if (obj.y <= GPU._curline && (obj.y + 8) > GPU._curline)
                        {
                            if (obj.yflip != 0)
                                tilerow = new { x = obj.tile, y = 7 - (GPU._curline - obj.y) };// GPU._tilemap[obj.tile][7 - (GPU._curline - obj.y)];
                            else
                                tilerow = new { x = obj.tile, y = GPU._curline - obj.y };//GPU._tilemap[obj.tile][GPU._curline - obj.y];

                            if (obj.palette != 0) pal = GPU._palette.obj1;
                            else pal = GPU._palette.obj0;

                            linebase = (GPU._curline * 160 + obj.x) * 4;
                            if (obj.xflip != 0)
                            {
                                for (x = 0; x < 8; x++)
                                {
                                    if (obj.x + x >= 0 && obj.x + x < 160)
                                    {
                                        if ((GPU._tilemap[tilerow.x, tilerow.y, 7 - x] != 0) && (obj.prio != 0 || GPU._scanrow[x] == 0)) // todo check this logic
                                        {
                                            GPU._scrn.data[linebase + 3] = pal[GPU._tilemap[tilerow.x, tilerow.y, 7 - x]];
                                        }
                                    }
                                    linebase += 4;
                                }
                            }
                            else
                            {
                                for (x = 0; x < 8; x++)
                                {
                                    if (obj.x + x >= 0 && obj.x + x < 160)
                                    {
                                        if (GPU._tilemap[tilerow.x, tilerow.y, x] != 0 && (obj.prio != 0 || GPU._scanrow[x] == 0))
                                        {
                                            GPU._scrn.data[linebase + 3] = pal[GPU._tilemap[tilerow.x, tilerow.y, x]];
                                        }
                                    }
                                    linebase += 4;
                                }
                            }
                            cnt++; if (cnt > 10) break;
                        }
                    }
                }
            }
        }

        public static void updatetile(int addr, int val)
        {
            var saddr = addr;
            if ((addr & 1 ) != 0) { saddr--; addr--; }
            var tile = (addr >> 4) & 511;
            var y = (addr >> 1) & 7;
            int sx;
            for (var x = 0; x < 8; x++)
            {
                sx = 1 << (7 - x);
                GPU._tilemap[tile, y, x]= ((GPU._vram[saddr] & sx) != 0 ? 1 : 0) | ((GPU._vram[saddr + 1] & sx) != 0 ? 2 : 0);
            }
        }

        public static void updateoam(int addr, int val)
        {
            addr -= 0xFE00;
            var obj = addr >> 2;
            if (obj < 40)
            {
                switch (addr & 3)
                {
                    case 0: GPU._objdata[obj].y = val - 16; break;
                    case 1: GPU._objdata[obj].x = val - 8; break;
                    case 2:
                        if (GPU._objsize != 0) GPU._objdata[obj].tile = (val & 0xFE);
                        else GPU._objdata[obj].tile = val;
                        break;
                    case 3:
                        GPU._objdata[obj].palette = (val & 0x10) != 0 ? 1 : 0;
                        GPU._objdata[obj].xflip = (val & 0x20) != 0 ? 1 : 0;
                        GPU._objdata[obj].yflip = (val & 0x40) != 0 ? 1 : 0;
                        GPU._objdata[obj].prio = (val & 0x80) != 0 ? 1 : 0;
                        break;
                }
            }

            Array.Sort(GPU._objdatasorted, (a, b) => {
                if (a.x > b.x) return -1;
                if (a.num > b.num) return -1;
                return 0;
            });
        }

        public static int rb(int addr)
        {
            var gaddr = addr - 0xFF40;
            switch (gaddr)
            {
                case 0:
                    return (GPU._lcdon != 0 ? 0x80 : 0) |
                           ((GPU._bgtilebase == 0x0000) ? 0x10 : 0) |
                           ((GPU._bgmapbase == 0x1C00) ? 0x08 : 0) |
                           (GPU._objsize != 0 ? 0x04 : 0) |
                           (GPU._objon != 0? 0x02 : 0) |
                           (GPU._bgon != 0? 0x01 : 0);

                case 1:
                    return (GPU._curline == GPU._raster ? 4 : 0) | GPU._linemode;

                case 2:
                    return GPU._yscrl;

                case 3:
                    return GPU._xscrl;

                case 4:
                    return GPU._curline;

                case 5:
                    return GPU._raster;

                default:
                    return GPU._reg[gaddr];
            }
        }

        public static void wb(int addr, int val)
        {
            var gaddr = addr - 0xFF40;
            GPU._reg[gaddr] = val;
            switch (gaddr)
            {
                case 0:
                    GPU._lcdon = (val & 0x80) != 0 ? 1 : 0;
                    GPU._bgtilebase = (val & 0x10) != 0 ? 0x0000 : 0x0800;
                    GPU._bgmapbase = (val & 0x08) != 0 ? 0x1C00 : 0x1800;
                    GPU._objsize = (val & 0x04) != 0 ? 1 : 0;
                    GPU._objon = (val & 0x02) != 0 ? 1 : 0;
                    GPU._bgon = (val & 0x01) !=0 ? 1 : 0;
                    break;

                case 2:
                    GPU._yscrl = val;
                    break;

                case 3:
                    GPU._xscrl = val;
                    break;

                case 5:
                    GPU._raster = val;
                    goto case 6;

                // OAM DMA
                case 6:
                    int v;
                    for (var i = 0; i < 160; i++)
                    {
                        v = MMU.rb((val << 8) + i);
                        GPU._oam[i] = v;
                        GPU.updateoam(0xFE00 + i, v);
                    }
                    break;

                // BG palette mapping
                case 7:
                    for (var i = 0; i < 4; i++)
                    {
                        switch ((val >> (i * 2)) & 3)
                        {
                            case 0: GPU._palette.bg[i] = 255; break;
                            case 1: GPU._palette.bg[i] = 192; break;
                            case 2: GPU._palette.bg[i] = 96; break;
                            case 3: GPU._palette.bg[i] = 0; break;
                        }
                    }
                    break;

                // OBJ0 palette mapping
                case 8:
                    for (var i = 0; i < 4; i++)
                    {
                        switch ((val >> (i * 2)) & 3)
                        {
                            case 0: GPU._palette.obj0[i] = 255; break;
                            case 1: GPU._palette.obj0[i] = 192; break;
                            case 2: GPU._palette.obj0[i] = 96; break;
                            case 3: GPU._palette.obj0[i] = 0; break;
                        }
                    }
                    break;

                // OBJ1 palette mapping
                case 9:
                    for (var i = 0; i < 4; i++)
                    {
                        switch ((val >> (i * 2)) & 3)
                        {
                            case 0: GPU._palette.obj1[i] = 255; break;
                            case 1: GPU._palette.obj1[i] = 192; break;
                            case 2: GPU._palette.obj1[i] = 96; break;
                            case 3: GPU._palette.obj1[i] = 0; break;
                        }
                    }
                    break;
            }
        }

        public static void CopyScrnToCanvas()
        {
            BitmapData buflock = Display.buf.LockBits(new Rectangle(Point.Empty, Display.buf.Size), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);

            unsafe
            {
                Byte* bufdata = (Byte*)buflock.Scan0;
                Byte* pos = bufdata;

                for (int i = 0; i < _scrn.width; i++)
                {
                    for (int j = 0; j < _scrn.height; j++)
                    { 
                        *pos = (byte)(_canvas[i,j]);
                        pos++;
                    }
                }
            }

            Display.buf.UnlockBits(buflock);
        }
    }
}
