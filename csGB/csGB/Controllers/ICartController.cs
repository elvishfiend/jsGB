namespace csGB.Controllers
{
    public interface ICartController
    {
        int ReadByte(byte[] rom, byte[] ram, int addr);
        void WriteByte(byte[] rom, byte[] ram, int addr, int value);
    }
}