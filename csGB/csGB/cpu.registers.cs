using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csGB
{
    public static partial class cpu
    {
        public static register _r = new register();

        public struct register
        {
            public int a;
            public int b;
            public int c;
            public int d;
            public int e;
            public int h;
            public int l;
            public int f;
            public int sp;
            public int pc;
            public int i;
            public int r;
            public int m;
            public int ime;
        }
    }
}
