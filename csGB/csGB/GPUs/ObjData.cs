using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace csGB.GPUs
{
    struct ObjData
    {
        // 7: Obj/BG priority (0=obj above bg, 1=obj behind bg, except if BG color is 0)
        private const int OBJPRIORITY = 7;

        // 6: Y-Flip
        private const int YFLIP = 6;

        // 5: X-Flip
        private const int XFLIP = 5;

        // 4: Palette number (0=OBP0, 1=OBP1)
        private const int PALETTENO = 4;

        // 3-0: not in use

        public int Y;

        public int X;

        public int TileIndex;

        private int attribs;

        public int Attribs
        {
            get => attribs;
            set => LoadAttribs(value);
        }

        public bool ObjPriority { get; private set; }
        public bool YFlip { get; private set; }
        public bool XFlip { get; private set; }
        public bool PaletteNo { get; private set; }

        private void LoadAttribs(int value)
        {
            attribs = value;

            ObjPriority = (value & (1 << OBJPRIORITY)) != 0;
            YFlip = (value & (1 << YFLIP)) != 0;
            XFlip = (value & (1 << XFLIP)) != 0;
            PaletteNo = (value & (1 << PALETTENO)) != 0;
        }

        public int this[int index]
        {
            get
            {
                if (index == 0)
                    return Y;
                if (index == 1)
                    return X;
                if (index == 2)
                    return TileIndex;
                if (index == 3)
                    return attribs;
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (index == 0)
                    Y = value;
                else if (index == 1)
                    X = value;
                else if (index == 2)
                    TileIndex = value;
                else if (index == 3)
                    Attribs = value;
                else
                    throw new IndexOutOfRangeException();
            }
        }

        public void Reset()
        {
            Y = -16;
            X = -8;
            TileIndex = 0;
            Attribs = 0;
        }
    }
}
