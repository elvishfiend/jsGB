using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csGB
{
    public static partial class Z80
    {
        public static resetvector _rsv = new resetvector();

        public struct resetvector
        {
            public int a;
            public int b;
            public int c;
            public int d;
            public int e;
            public int h;
            public int l;
            public int f;
        }
    }
}
