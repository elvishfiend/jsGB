using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartAnalyzer
{
    class Cart
    {
        private Cart()
        {
        }

        // 0x0134 - 0x0142 - ASCII
        public string CartName { get; private set; }

        public string CartTypeName { get; private set; }

        // 0x143 - 0x80=ColorGB, anything else=non-ColorGB
        public bool ColorGB { get; private set; }

        // 0x146 - 00=GameBoy, 03=SGB
        public bool SGB { get; private set; }

        // 0x0147
        public int CartType { get; private set; }

        // 0x0148
        public int RomSize { get; private set; }
        public int RomBanks { get; private set; }

        // 0x0149
        public int RamSize { get; private set; }
        public int RamBanks { get; private set; }

        public Destination Destination { get; private set; }

        public static Cart GetFromFile(string path)
        {
            var rom = System.IO.File.ReadAllBytes(path);

            var cart = new Cart();

            byte[] nameRaw = new byte[16];
            Array.Copy(rom, 0x0134, nameRaw, 0, 16);
            cart.CartName = Encoding.ASCII.GetString(nameRaw);

            var cartType = rom[0x0147];
            cart.CartType = cartType;
            cart.CartTypeName = GetCartType(cartType);

            if (rom[0x0143] == 0x80)
                cart.ColorGB = true;
            else
                cart.ColorGB = false;

            if (rom[0x0146] == 03)
                cart.SGB = true;
            else
                cart.SGB = false;

            var romCode = rom[0x0148];
            cart.RomBanks = GetRomBanks(romCode);
            cart.RomSize = GetRomSizeKB(romCode);

            var ramCode = rom[0x0149];
            cart.RamBanks = GetRamBanks(ramCode); 
            cart.RamSize = GetRamSizeKB(ramCode);

            return cart;
        }

        private static int GetRomBanks(int romCode)
        {
            if (romCode <= 6)
                return (int)(2 * Math.Pow(2, romCode));
            if (romCode == 0x52)
                return 72;
            if (romCode == 0x53)
                return 80;
            if (romCode == 0x54)
                return 96;

            throw new Exception();
        }

        private static int GetRomSizeKB(int romCode)
        {
            var numBanks = GetRomBanks(romCode);

            // each bank is 16KB
            return numBanks * 16;
        }

        private static int GetRamBanks(int ramCode)
        {
            switch (ramCode)
            {
                case 0:
                    return 0;
                case 1:
                case 2:
                    return 1;
                case 3:
                    return 4;
                case 4:
                    return 16;
                default:
                    throw new Exception("Unknown RamCode: " + ramCode);
            }
        }

        private static int GetRamSizeKB(int ramCode)
        {
            switch (ramCode)
            {
                case 0:
                    return 0;
                case 1:
                    return 2;
                case 2:
                    return 8;
                case 3:
                    return 32;
                case 4:
                    return 128;
                default:
                    throw new Exception("Unknown RamCode: " + ramCode);
            }
        }

        private static string GetCartType(int cartType)
        {
            switch (cartType)
            {
                case 0: return "ROM ONLY";
                case 1: return "ROM + MBC1";
                case 2: return "ROM + MBC1 + RAM";
                case 3: return "ROM + MBC1 + RAM + BATT";
                case 5: return "ROM + MBC2";
                case 6: return "ROM + MBC2 + BATTERY";
                case 8: return "ROM + RAM";
                case 9: return "ROM + RAM + BATTERY";    
                case 0xB: return "ROM + MMM01";
                case 0xC: return "ROM + MMM01 + SRAM";
                case 0xD: return "ROM + MMM01 + SRAM + BATT";
                case 0xF: return "ROM + MBC3 + TIMER + BATT";

                case 0x10: return "ROM + MBC3 + TIMER + RAM + BATT";
                case 0x11: return "ROM + MBC3";
                case 0x12: return "ROM + MBC3 + RAM";
                case 0x13: return "ROM + MBC3 + RAM + BATT";
                case 0x19: return "ROM + MBC5";
                case 0x1A: return "ROM + MBC5 + RAM";
                case 0x1B: return "ROM + MBC5 + RAM + BATT";
                case 0x1C: return "ROM + MBC5 + RUMBLE";
                case 0x1D: return "ROM + MBC5 + RUMBLE + SRAM";
                case 0x1E: return "ROM + MBC5 + RUMBLE + SRAM + BATT";
                case 0x1F: return "Pocket Camera C-ROM + MMM01 + SRAM";

                case 0xFD: return "Bandai TAMA5 D-ROM + MMM01 + SRAM + BATT";
                case 0xFE: return "Hudson HuC - 3";
                case 0xFF: return "Hudson HuC - 1";
                default: throw new Exception();
            }
        }
    }
}
