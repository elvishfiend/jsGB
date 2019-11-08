using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csGB.GPUs
{
    public class fullGPU : GPUs.IGPU
    {
        int[] IGPU.VRAM => _vram;
        int[] IGPU.OAM => _oam;
        int[] IGPU.REG => _reg;

        public Action<byte[]> DrawScreenCallback { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int[] _vram = new int[8192];
        public int[] _oam = new int[160];
        public int[] _reg = new int[10];
        public int[,,] _tilemap = new int[512, 8, 8];
        public ObjData[] _objdata = new ObjData[40];
        public ObjData[] _objdatasorted = new ObjData[40];

        public int[,] _canvas = new int[160, 144];

        public Palette _palette = new Palette();

        public class Palette
        {
            public int[] bg = new int[4];
            public int[] obj0 = new int[4];
            public int[] obj1 = new int[4];
        }

        public static Screen _scrn = new Screen();

        public class Screen
        {
            public int width = 160;
            public int height = 144;
            public int[] data = new int[160 * 144];
        }

        public class ObjData
        {
            public int y = -16;
            public int x = -8;
            public int tile = 0;
            public int palette = 0;
            public int yflip = 0;
            public int xflip = 0;
            public int prio = 0;
            public int num = 0;
        }

        public static int[] _scanrow = new int[160];

        public int _curline = 0;
        public int _curscan = 0;
        public int _linemode = 0;
        public int _modeclocks = 0;

        public int _yscrl = 0;
        public int _xscrl = 0;
        public int _raster = 0;
        public int _ints = 0;

        public int _lcdon = 0;
        public int _bgon = 0;
        public int _objon = 0;
        public int _winon = 0;

        public int _objsize = 0;

        public int _bgtilebase = 0x0000;
        public int _bgmapbase = 0x1800;
        public int _wintilebase = 0x1800;

        public void Reset()
        {
            _vram = new int[8192];
            _oam = new int[160];

            for (int i = 0; i < 4; i++)
            {
                _palette.bg[i] = 255;
                _palette.obj0[i] = 255;
                _palette.obj1[i] = 255;
            }

            _tilemap = new int[512, 8, 8];

            LOG.@out("GPU", "Initialising screen.");

            _canvas = new int[160, 144];
            for (int i = 0; i < _scrn.data.Length; i++)
                _scrn.data[i] = 255;

            CopyScrnToCanvas();

            _curline = 0;
            _curscan = 0;
            _linemode = 2;
            _modeclocks = 0;
            _yscrl = 0;
            _xscrl = 0;
            _raster = 0;
            _ints = 0;

            _lcdon = 0;
            _bgon = 0;
            _objon = 0;
            _winon = 0;

            _objsize = 0;
            _scanrow = new int[160];

            for (int i = 0; i < 40; i++)
            {
                _objdata[i] = new ObjData
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
            _bgtilebase = 0x0000;
            _bgmapbase = 0x1800;
            _wintilebase = 0x1800;

            LOG.@out("GPU", "Reset.");
        }

        public void Step()
        {
            _modeclocks += Z80._r.m;
            switch (_linemode)
            {
                // In hblank
                case 0:
                    if (_modeclocks >= 51)
                    {
                        // End of hblank for last scanline; render screen
                        if (_curline == 143)
                        {
                            _linemode = 1;
                            CopyScrnToCanvas(); //GPU._canvas.putImageData(GPU._scrn, 0, 0);
                            MMU._if |= 1;
                        }
                        else
                        {
                            _linemode = 2;
                        }
                        _curline++;
                        _curscan += 640;
                        _modeclocks = 0;
                    }
                    break;

                // In vblank
                case 1:
                    if (_modeclocks >= 114)
                    {
                        _modeclocks = 0;
                        _curline++;
                        if (_curline > 153)
                        {
                            _curline = 0;
                            _curscan = 0;
                            _linemode = 2;
                        }
                    }
                    break;

                // In OAM-read mode
                case 2:
                    if (_modeclocks >= 20)
                    {
                        _modeclocks = 0;
                        _linemode = 3;
                    }
                    break;

                // In VRAM-read mode
                case 3:
                    // Render scanline at end of allotted time
                    if (_modeclocks >= 43)
                    {
                        _modeclocks = 0;
                        _linemode = 0;
                        if (_lcdon != 0)
                        {
                            if (_bgon != 0)
                            {
                                var linebase = _curscan;
                                var mapbase = _bgmapbase + ((((_curline + _yscrl) & 255) >> 3) << 5);
                                var y = (_curline + _yscrl) & 7;
                                var x = _xscrl & 7;
                                var t = (_xscrl >> 3) & 31;
                                var w = 160;

                                var tilerow = new { x = 0, y = 0 };

                                if (_bgtilebase != 0)
                                {
                                    var tile = _vram[mapbase + t];
                                    if (tile < 128) tile = 256 + tile;
                                    tilerow = new { x = tile, y };
                                    do
                                    {
                                        _scanrow[160 - x] = _tilemap[tilerow.x, tilerow.y, x];
                                        _scrn.data[linebase + 3] = _palette.bg[_tilemap[tilerow.x, tilerow.y, x]];
                                        x++;
                                        if (x == 8) { t = (t + 1) & 31; x = 0; tile = _vram[mapbase + t]; if (tile < 128) tile = 256 + tile; tilerow = new { x = tile, y }; }
                                        linebase += 4;
                                    } while (--w > 0);
                                }
                                else
                                {
                                    tilerow = new { x = _vram[mapbase + t], y };
                                    do
                                    {
                                        _scanrow[160 - x] = _tilemap[tilerow.x, tilerow.y, x];
                                        _scrn.data[linebase + 3] = _palette.bg[_tilemap[tilerow.x, tilerow.y, x]];
                                        x++;
                                        if (x == 8) { t = (t + 1) & 31; x = 0; tilerow = new { x = _vram[mapbase + t], y }; }
                                        linebase += 4;
                                    } while (--w > 0);
                                }
                            }
                            if (_objon != 0)
                            {
                                var cnt = 0;
                                if (_objsize != 0)
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
                                    var linebase = _curscan;
                                    for (var i = 0; i < 40; i++)
                                    {
                                        obj = _objdatasorted[i];
                                        if (obj.y <= _curline && (obj.y + 8) > _curline)
                                        {
                                            if (obj.yflip != 0)
                                                tilerow = new { x = obj.tile, y = 7 - (_curline - obj.y) };// _tilemap[obj.tile][7 - (_curline - obj.y)];
                                            else
                                                tilerow = new { x = obj.tile, y = _curline - obj.y };//_tilemap[obj.tile][_curline - obj.y];

                                            if (obj.palette != 0) pal = _palette.obj1;
                                            else pal = _palette.obj0;

                                            linebase = (_curline * 160 + obj.x) * 4;
                                            if (obj.xflip != 0)
                                            {
                                                for (x = 0; x < 8; x++)
                                                {
                                                    if (obj.x + x >= 0 && obj.x + x < 160)
                                                    {
                                                        if ((_tilemap[tilerow.x, tilerow.y, 7 - x] != 0) && (obj.prio != 0 || _scanrow[x] == 0)) // todo check this logic
                                                        {
                                                            _scrn.data[linebase + 3] = pal[_tilemap[tilerow.x, tilerow.y, 7 - x]];
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
                                                        if (_tilemap[tilerow.x, tilerow.y, x] != 0 && (obj.prio != 0 || _scanrow[x] == 0))
                                                        {
                                                            _scrn.data[linebase + 3] = pal[_tilemap[tilerow.x, tilerow.y, x]];
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
                    }
                    break;
            }
        }

        public void updatetile(int addr, int val)
        {
            var saddr = addr;
            if ((addr & 1) != 0) { saddr--; addr--; }
            var tile = (addr >> 4) & 511;
            var y = (addr >> 1) & 7;
            int sx;
            for (var x = 0; x < 8; x++)
            {
                sx = 1 << (7 - x);
                _tilemap[tile, y, x] = ((_vram[saddr] & sx) != 0 ? 1 : 0) | ((_vram[saddr + 1] & sx) != 0 ? 2 : 0);
            }
        }

        public void updateoam(int addr, int val)
        {
            addr -= 0xFE00;
            var obj = addr >> 2;
            if (obj < 40)
            {
                switch (addr & 3)
                {
                    case 0: _objdata[obj].y = val - 16; break;
                    case 1: _objdata[obj].x = val - 8; break;
                    case 2:
                        if (_objsize != 0) _objdata[obj].tile = (val & 0xFE);
                        else _objdata[obj].tile = val;
                        break;
                    case 3:
                        _objdata[obj].palette = (val & 0x10) != 0 ? 1 : 0;
                        _objdata[obj].xflip = (val & 0x20) != 0 ? 1 : 0;
                        _objdata[obj].yflip = (val & 0x40) != 0 ? 1 : 0;
                        _objdata[obj].prio = (val & 0x80) != 0 ? 1 : 0;
                        break;
                }
            }

            _objdatasorted = _objdata;
            Array.Sort(_objdatasorted, (a, b) => {
                if (a.x > b.x) return -1;
                if (a.num > b.num) return -1;
                return 0;
            });
        }

        public int ReadByte(int addr)
        {
            var gaddr = addr - 0xFF40;
            switch (gaddr)
            {
                case 0:
                    return (_lcdon != 0 ? 0x80 : 0) |
                           ((_bgtilebase == 0x0000) ? 0x10 : 0) |
                           ((_bgmapbase == 0x1C00) ? 0x08 : 0) |
                           (_objsize != 0 ? 0x04 : 0) |
                           (_objon != 0 ? 0x02 : 0) |
                           (_bgon != 0 ? 0x01 : 0);

                case 1:
                    return (_curline == _raster ? 4 : 0) | _linemode;

                case 2:
                    return _yscrl;

                case 3:
                    return _xscrl;

                case 4:
                    return _curline;

                case 5:
                    return _raster;

                default:
                    return _reg[gaddr];
            }
        }

        public void WriteByte(int addr, int val)
        {
            var gaddr = addr - 0xFF40;
            _reg[gaddr] = val;
            switch (gaddr)
            {
                case 0:
                    _lcdon = (val & 0x80) != 0 ? 1 : 0;
                    _bgtilebase = (val & 0x10) != 0 ? 0x0000 : 0x0800;
                    _bgmapbase = (val & 0x08) != 0 ? 0x1C00 : 0x1800;
                    _objsize = (val & 0x04) != 0 ? 1 : 0;
                    _objon = (val & 0x02) != 0 ? 1 : 0;
                    _bgon = (val & 0x01) != 0 ? 1 : 0;
                    break;

                case 2:
                    _yscrl = val;
                    break;

                case 3:
                    _xscrl = val;
                    break;

                case 5:
                    _raster = val;
                    goto case 6;

                // OAM DMA
                case 6:
                    int v;
                    for (var i = 0; i < 160; i++)
                    {
                        v = MMU.rb((val << 8) + i);
                        _oam[i] = v;
                        updateoam(0xFE00 + i, v);
                    }
                    break;

                // BG palette mapping
                case 7:
                    for (var i = 0; i < 4; i++)
                    {
                        switch ((val >> (i * 2)) & 3)
                        {
                            case 0: _palette.bg[i] = 255; break;
                            case 1: _palette.bg[i] = 192; break;
                            case 2: _palette.bg[i] = 96; break;
                            case 3: _palette.bg[i] = 0; break;
                        }
                    }
                    break;

                // OBJ0 palette mapping
                case 8:
                    for (var i = 0; i < 4; i++)
                    {
                        switch ((val >> (i * 2)) & 3)
                        {
                            case 0: _palette.obj0[i] = 255; break;
                            case 1: _palette.obj0[i] = 192; break;
                            case 2: _palette.obj0[i] = 96; break;
                            case 3: _palette.obj0[i] = 0; break;
                        }
                    }
                    break;

                // OBJ1 palette mapping
                case 9:
                    for (var i = 0; i < 4; i++)
                    {
                        switch ((val >> (i * 2)) & 3)
                        {
                            case 0: _palette.obj1[i] = 255; break;
                            case 1: _palette.obj1[i] = 192; break;
                            case 2: _palette.obj1[i] = 96; break;
                            case 3: _palette.obj1[i] = 0; break;
                        }
                    }
                    break;
            }
        }

        public void CopyScrnToCanvas()
        {
            int scrnPos = 0;

            for (int i = 0; i < 160; i++)
            {
                for (int j = 0; j < 144; j++)
                {
                    //for (int k = 0; k < 4; k++)
                    //{
                    _canvas[i, j] = _scrn.data[scrnPos++];
                    //}
                }
            }

            BitmapData buflock = Display.buf.LockBits(new Rectangle(Point.Empty, Display.buf.Size), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);

            unsafe
            {
                Byte* bufdata = (Byte*)buflock.Scan0;
                Byte* pos = bufdata;

                for (int i = 0; i < 160; i++)
                {
                    for (int j = 0; j < 144; j++)
                    {
                        var sum = 0;
                        //for (int k = 0; k < 4; k++)
                        //{

                        //}
                        sum += _canvas[i, j];
                        *pos = (byte)(sum / 4);
                    }
                }
            }

            Display.buf.UnlockBits(buflock);
        }

        public void DrawScreen()
        {
            throw new NotImplementedException();
        }

        public Bitmap InitializeScreen()
        {
            throw new NotImplementedException();
        }
    }
}
