using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csGB.GPUs
{
    public interface IGPU
    {
        int ReadByte(int addr);

        void WriteByte(int addr, int value);

        void Reset();

        void Step();

        int[] OAM { get; }
        int[] VRAM { get; }
        int[] REG { get; }

        void DrawScreen();

        Action<byte[]> DrawScreenCallback { get; set; }

        Bitmap InitializeScreen();
    }
    


}
