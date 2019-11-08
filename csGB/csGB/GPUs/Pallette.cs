using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csGB.GPUs
{
    struct Palette
    {
        private int[] shades;
        public int this[int i]
        {
            get => shades[i];
            set => shades[i] = value;
        }

        public Palette(byte val)
        {
            shades = new int[4];

            int data = val;
            shades[0] = (byte)(val & 0b11);
            data = data >> 2;
            shades[1] = (byte)(val & 0b11);
            data = data >> 2;
            shades[2] = (byte)(val & 0b11);
            data = data >> 2;
            shades[3] = (byte)(val & 0b11);
        }

        public Palette(int val)
        {
            shades = new int[4];

            int data = val;
            shades[0] = (byte)(data & 0b11);
            data = data >> 2;
            shades[1] = (byte)(data & 0b11);
            data = data >> 2;
            shades[2] = (byte)(data & 0b11);
            data = data >> 2;
            shades[3] = (byte)(data & 0b11);
        }
    }
}
