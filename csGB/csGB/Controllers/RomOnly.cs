using System;

namespace csGB.Controllers
{
    [CartType(0)]
    internal class RomOnly : ICartController
    {
        public int ReadByte(byte[] rom, byte[] ram, int addr)
        {
            return rom[addr];
        }

        public void WriteByte(byte[] rom, byte[] ram, int addr, int value)
        {
            return;
        }
    }
}