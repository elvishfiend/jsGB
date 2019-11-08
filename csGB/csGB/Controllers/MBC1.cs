using System;

namespace csGB.Controllers
{
    internal class ROM_MBC1 : ICartController
    {
        internal int mode; // 0: 16/8, 1: 4/32

        internal int romBank = 0;
        internal int romBankSize = 16 * 1024; // 16kB

        internal int ramBank = 0;
        internal int ramBankSize = 8 * 1024; // 8kB

        internal int romAddressUpperBits = 0;

        bool ramEnabled = false;

        public int ReadByte(byte[] rom, byte[] ram, int addr)
        {
            if (addr < 0x4000)
                return rom[addr];

            // read from Upper Rom
            if (addr >= 0x4000 && addr < 0x8000)
            {
                var index = addr - 0x4000;

                if (mode == 0)
                    return index + (romBank * romBankSize);
                if (mode == 1)
                    return (0b0011_1111 & index) + romAddressUpperBits + (romBank * romBankSize); // fix me: needs upper addr masking
            }

            if (addr >= 0xA000 && addr < 0xC000)
                return (addr - 0xA000) + (ramBank * ramBankSize);

            throw new InvalidOperationException("Attempted to read from invalid address in Cartridge");
        }

        public void WriteByte(byte[] rom, byte[] ram, int addr, int value)
        {
            switch(addr & 0xF000)
            {
                case 0x0000:
                case 0x1000:
                    if ((value & 0x0F) == 0b00001010) // 0xXA
                        ramEnabled = true;
                    else
                        ramEnabled = false;
                    return;

                case 0x2000:
                case 0x3000:
                    romBank = value & 0b0001_1111;
                    if (romBank % 0x20 == 0) romBank += 1; // bank $00 => $01, $20 => $21 etc.
                    return;

                case 0x4000:
                case 0x5000:
                    if (mode == 0)
                        ramBank = value & 0b0000_0011;

                    if (mode == 1)
                        romAddressUpperBits = (value & 0b0000_0011) << 6; // Sets the 2 MSB address lines
                    
                    return;
                case 0x6000:
                case 0x7000:
                    mode = value & 0b0000_0001;
                    return;
                default:
                    WriteRam(ram, addr, value);
                    return;
            }
        }

        private void WriteRam(byte[] ram, int addr, int value)
        {
            if (!ramEnabled)
                return;

            if (addr < 0xA000 || addr > 0xC000)
                return;

            var index = (addr - 0xA000) + ramBank * ramBankSize;

            if (index < ram.Length)
                ram[index] = (byte)value;
        }
    }
}