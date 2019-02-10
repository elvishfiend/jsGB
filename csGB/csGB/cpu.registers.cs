using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csGB
{
    public static partial class Z80
    {
        public static register _r = new register();

        public struct register
        {
            /// <summary>
            /// A register
            /// </summary>
            public int a
            {
                get => _a;
                set => _a = value & 0xFF;
            }
            private int _a;

            /// <summary>
            /// Flags register
            /// </summary>
            public int f
            {
                get => _f;
                set => _f = value & 0xFF;
            }
            private int _f;

            /// <summary>
            /// B register
            /// </summary>
            public int b
            {
                get => _b;
                set => _b = value & 0xFF;
            }
            private int _b;

            /// <summary>
            /// C register
            /// </summary>
            public int c
            {
                get => _c;
                set => _c = value & 0xFF;
            }
            private int _c;

            /// <summary>
            /// D register
            /// </summary>
            public int d
            {
                get => _d;
                set => _d = value & 0xFF;
            }
            private int _d;

            /// <summary>
            /// E register
            /// </summary>
            public int e
            {
                get => _e;
                set => _e = value & 0xFF;
            }
            private int _e;

            /// <summary>
            /// High register
            /// </summary>
            public int h
            {
                get => _h;
                set => _h = value & 0xFF;
            }
            private int _h;

            /// <summary>
            /// Low register
            /// </summary>
            public int l
            {
                get => _l;
                set => _l = value & 0xFF;
            }
            private int _l;

            /// <summary>
            /// Stack Pointer register
            /// </summary>
            public int sp
            {
                get => _sp;
                set => _sp = value & 0xFF;
            }
            private int _sp;

            /// <summary>
            /// Program Counter register
            /// </summary>
            public int pc {
                get => _pc;
                set => _pc = value & 0xFFFF;
            }
            private int _pc;

            /// <summary>
            /// 
            /// </summary>
            public int i { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public int r { get; set; }

            /// <summary>
            /// holds the length in clock cycles of the last executed instruction
            /// </summary>
            public int m { get; set; }

            /// <summary>
            /// Interrupt Master Enable flag. Set by EI(), cleared by DI()
            /// </summary>
            public bool ime { get; set; }
        }
    }
}
