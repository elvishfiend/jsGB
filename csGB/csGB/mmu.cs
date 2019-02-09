using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csGB
{
    public static class MMU
    {
        public static int[] _bios = new[]
        {
            0x31, 0xFE, 0xFF, 0xAF, 0x21, 0xFF, 0x9F, 0x32, 0xCB, 0x7C, 0x20, 0xFB, 0x21, 0x26, 0xFF, 0x0E,
            0x11, 0x3E, 0x80, 0x32, 0xE2, 0x0C, 0x3E, 0xF3, 0xE2, 0x32, 0x3E, 0x77, 0x77, 0x3E, 0xFC, 0xE0,
            0x47, 0x11, 0x04, 0x01, 0x21, 0x10, 0x80, 0x1A, 0xCD, 0x95, 0x00, 0xCD, 0x96, 0x00, 0x13, 0x7B,
            0xFE, 0x34, 0x20, 0xF3, 0x11, 0xD8, 0x00, 0x06, 0x08, 0x1A, 0x13, 0x22, 0x23, 0x05, 0x20, 0xF9,
            0x3E, 0x19, 0xEA, 0x10, 0x99, 0x21, 0x2F, 0x99, 0x0E, 0x0C, 0x3D, 0x28, 0x08, 0x32, 0x0D, 0x20,
            0xF9, 0x2E, 0x0F, 0x18, 0xF3, 0x67, 0x3E, 0x64, 0x57, 0xE0, 0x42, 0x3E, 0x91, 0xE0, 0x40, 0x04,
            0x1E, 0x02, 0x0E, 0x0C, 0xF0, 0x44, 0xFE, 0x90, 0x20, 0xFA, 0x0D, 0x20, 0xF7, 0x1D, 0x20, 0xF2,
            0x0E, 0x13, 0x24, 0x7C, 0x1E, 0x83, 0xFE, 0x62, 0x28, 0x06, 0x1E, 0xC1, 0xFE, 0x64, 0x20, 0x06,
            0x7B, 0xE2, 0x0C, 0x3E, 0x87, 0xF2, 0xF0, 0x42, 0x90, 0xE0, 0x42, 0x15, 0x20, 0xD2, 0x05, 0x20,
            0x4F, 0x16, 0x20, 0x18, 0xCB, 0x4F, 0x06, 0x04, 0xC5, 0xCB, 0x11, 0x17, 0xC1, 0xCB, 0x11, 0x17,
            0x05, 0x20, 0xF5, 0x22, 0x23, 0x22, 0x23, 0xC9, 0xCE, 0xED, 0x66, 0x66, 0xCC, 0x0D, 0x00, 0x0B,
            0x03, 0x73, 0x00, 0x83, 0x00, 0x0C, 0x00, 0x0D, 0x00, 0x08, 0x11, 0x1F, 0x88, 0x89, 0x00, 0x0E,
            0xDC, 0xCC, 0x6E, 0xE6, 0xDD, 0xDD, 0xD9, 0x99, 0xBB, 0xBB, 0x67, 0x63, 0x6E, 0x0E, 0xEC, 0xCC,
            0xDD, 0xDC, 0x99, 0x9F, 0xBB, 0xB9, 0x33, 0x3E, 0x3c, 0x42, 0xB9, 0xA5, 0xB9, 0xA5, 0x42, 0x4C,
            0x21, 0x04, 0x01, 0x11, 0xA8, 0x00, 0x1A, 0x13, 0xBE, 0x20, 0xFE, 0x23, 0x7D, 0xFE, 0x34, 0x20,
            0xF5, 0x06, 0x19, 0x78, 0x86, 0x23, 0x05, 0x20, 0xFB, 0x86, 0x20, 0xFE, 0x3E, 0x01, 0xE0, 0x50
        };

        public static byte[] _rom;
        public static int _carttype = 0;

        public class MBC
        {
            public int rombank;
            public int rambank;
            public int ramon;
            public int mode;
        }
        public static MBC[] _mbc = new MBC[]
        {
            new MBC(), new MBC()
        };
        
        public static int _romoffs = 0x4000;
        public static int _ramoffs = 0;

        public static int[] _eram = new int[1024];
        public static int[] _wram = new int[1024];
        public static int[] _zram = new int[1024];

        public static bool _inbios = true;
        public static int _ie = 0;
        public static int _if = 0;

        public static void reset()
        {
            for (int i = 0; i < 8192; i++) MMU._wram[i] = 0;
            for (int i = 0; i < 32768; i++) MMU._eram[i] = 0;
            for (int i = 0; i < 127; i++) MMU._zram[i] = 0;

            MMU._inbios = true;
            MMU._ie = 0;
            MMU._if = 0;

            MMU._carttype = 0;
            MMU._mbc[0] = new MBC();
            MMU._mbc[1] = new MBC() { rombank = 0, rambank = 0, ramon = 0, mode = 0 };
            MMU._romoffs = 0x4000;
            MMU._ramoffs = 0;

            Console.WriteLine("MMU - Reset.");
        }

        public static void load(string file)
        {
            MMU._rom = System.IO.File.ReadAllBytes(file);
            MMU._carttype = MMU._rom[0x0147];
        
            LOG.@out("MMU", "ROM loaded, " + MMU._rom.Length + " bytes.");
        }

        public static int rb(int addr)
        {
            switch (addr & 0xF000)
            {
                // ROM bank 0
                case 0x0000:
                    if (MMU._inbios)
                    {
                        if (addr < 0x0100) return MMU._bios[addr];
                        else if (Z80._r.pc == 0x0100)
                        {
                            MMU._inbios = false;
                            LOG.@out("MMU", "Leaving BIOS.");
                            return rb(addr);
                        }
                    }
                    else
                    {
                        return MMU._rom[addr];
                    }
                    break;

                case 0x1000:
                case 0x2000:
                case 0x3000:
                    return MMU._rom[addr];

                // ROM bank 1
                case 0x4000:
                case 0x5000:
                case 0x6000:
                case 0x7000:
                    return MMU._rom[MMU._romoffs + (addr & 0x3FFF)];

                // VRAM
                case 0x8000:
                case 0x9000:
                    return GPU._vram[addr & 0x1FFF];

                // External RAM
                case 0xA000:
                case 0xB000:
                    return MMU._eram[MMU._ramoffs + (addr & 0x1FFF)];

                // Work RAM and echo
                case 0xC000:
                case 0xD000:
                case 0xE000:
                    return MMU._wram[addr & 0x1FFF];

                // Everything else
                case 0xF000:
                    switch (addr & 0x0F00)
                    {
                        // Echo RAM
                        case 0x000:
                        case 0x100:
                        case 0x200:
                        case 0x300:
                        case 0x400:
                        case 0x500:
                        case 0x600:
                        case 0x700:
                        case 0x800:
                        case 0x900:
                        case 0xA00:
                        case 0xB00:
                        case 0xC00:
                        case 0xD00:
                            return MMU._wram[addr & 0x1FFF];

                        // OAM
                        case 0xE00:
                            return ((addr & 0xFF) < 0xA0) ? GPU._oam[addr & 0xFF] : 0;

                        // Zeropage RAM, I/O, interrupts
                        case 0xF00:
                            if (addr == 0xFFFF) { return MMU._ie; }
                            else if (addr > 0xFF7F) { return MMU._zram[addr & 0x7F]; }
                            else
                                switch (addr & 0xF0)
                                {
                                    case 0x00:
                                        switch (addr & 0xF)
                                        {
                                            case 0: return KEY.rb();    // JOYP
                                            case 4:
                                            case 5:
                                            case 6:
                                            case 7:
                                                return TIMER.rb(addr);
                                            case 15: return MMU._if;    // Interrupt flags
                                            default: return 0;
                                        }

                                    case 0x10:
                                    case 0x20:
                                    case 0x30:
                                        return 0;

                                    case 0x40:
                                    case 0x50:
                                    case 0x60:
                                    case 0x70:
                                        return GPU.rb(addr);
                                }

                            break;
                        }

                    break;
                }
            throw new InvalidOperationException($"Unable to read address {addr}: Out of range.");
        }

        public static int rw(int addr) { return MMU.rb(addr) + (MMU.rb(addr + 1) << 8); }

        public static void wb(int addr, int val)
        {
            byte bval = (byte)val;

            switch (addr & 0xF000)
            {
                // ROM bank 0
                // MBC1: Turn external RAM on
                case 0x0000:
                case 0x1000:
                    switch (MMU._carttype)
                    {
                        case 1:
                            MMU._mbc[1].ramon = ((bval & 0xF) == 0xA) ? 1 : 0;
                            break;
                    }
                    break;

                // MBC1: ROM bank switch
                case 0x2000:
                case 0x3000:
                    switch (MMU._carttype)
                    {
                        case 1:
                            MMU._mbc[1].rombank &= 0x60;
                            bval &= 0x1F;
                            if (bval == 0) bval = 1;
                            MMU._mbc[1].rombank |= bval;
                            MMU._romoffs = MMU._mbc[1].rombank * 0x4000;
                            break;
                    }
                    break;

                // ROM bank 1
                // MBC1: RAM bank switch
                case 0x4000:
                case 0x5000:
                    switch (MMU._carttype)
                    {
                        case 1:
                            if (MMU._mbc[1].mode != 0)
                            {
                                MMU._mbc[1].rambank = (bval & 3);
                                MMU._ramoffs = MMU._mbc[1].rambank * 0x2000;
                            }
                            else
                            {
                                MMU._mbc[1].rombank &= 0x1F;
                                MMU._mbc[1].rombank |= ((bval & 3) << 5);
                                MMU._romoffs = MMU._mbc[1].rombank * 0x4000;
                            }
                            break;
                    }
                    break;

                case 0x6000:
                case 0x7000:
                    switch (MMU._carttype)
                    {
                        case 1:
                            MMU._mbc[1].mode = bval & 1;
                            break;
                    }
                    break;

                // VRAM
                case 0x8000:
                case 0x9000:
                    GPU._vram[addr & 0x1FFF] = bval;
                    GPU.updatetile(addr & 0x1FFF, bval);
                    break;

                // External RAM
                case 0xA000:
                case 0xB000:
                    MMU._eram[MMU._ramoffs + (addr & 0x1FFF)] = bval;
                    break;

                // Work RAM and echo
                case 0xC000:
                case 0xD000:
                case 0xE000:
                    MMU._wram[addr & 0x1FFF] = bval;
                    break;

                // Everything else
                case 0xF000:
                    switch (addr & 0x0F00)
                    {
                        // Echo RAM
                        case 0x000:
                        case 0x100:
                        case 0x200:
                        case 0x300:
                        case 0x400:
                        case 0x500:
                        case 0x600:
                        case 0x700:
                        case 0x800:
                        case 0x900:
                        case 0xA00:
                        case 0xB00:
                        case 0xC00:
                        case 0xD00:
                            MMU._wram[addr & 0x1FFF] = bval;
                            break;

                        // OAM
                        case 0xE00:
                            if ((addr & 0xFF) < 0xA0) GPU._oam[addr & 0xFF] = bval;
                            GPU.updateoam(addr, bval);
                            break;

                        // Zeropage RAM, I/O, interrupts
                        case 0xF00:
                            if (addr == 0xFFFF) { MMU._ie = bval; }
                            else if (addr > 0xFF7F) { MMU._zram[addr & 0x7F] = bval; }
                            else switch (addr & 0xF0)
                                {
                                    case 0x00:
                                        switch (addr & 0xF)
                                        {
                                            case 0: KEY.wb(bval); break;
                                            case 4: case 5: case 6: case 7: TIMER.wb(addr, bval); break;
                                            case 15: MMU._if = bval; break;
                                        }
                                        break;

                                    case 0x10:
                                    case 0x20:
                                    case 0x30:
                                        break;

                                    case 0x40:
                                    case 0x50:
                                    case 0x60:
                                    case 0x70:
                                        GPU.wb(addr, bval);
                                        break;
                                }
                            break;
                    }

                    break;
            }
        }

        public static void ww(int addr, int val) { MMU.wb(addr, val & 255); MMU.wb(addr + 1, val >> 8); }
    };

}
