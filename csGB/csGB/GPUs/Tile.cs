using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csGB.GPUs
{
    struct Tile
    {
        public int[,] pixels;

        public Tile(int[] data)
        {
            // data should be 16 bytes long

            pixels = new int[8, 8];

            for (int i = 0; i < 16; i += 2)
            {
                for (int j = 7; j >= 0; j--)
                {
                    // first byte is low bit, second byte is high bit
                    // bit 7 is the leftmost, bit 0 is the rightmost

                    var bitmask = 0x1 << j;

                    var lowBit = data[i] & bitmask;
                    var highBit = data[i + 1] & bitmask;

                    var value = (highBit == 0 ? 0 : 2) + (lowBit == 0 ? 0 : 1);

                    pixels[i / 2, j] = value;
                }
            }

        }

        public void Reset()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    pixels[i, j] = 0;
        }
    }
}
