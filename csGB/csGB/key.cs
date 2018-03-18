using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csGB
{
    public static class KEY
    {
        public static int[] _keys = new[] { 0x0F, 0x0F };
        public static int _colidx = 0;

        public static void reset()
        {
            KEY._keys = new[] { 0x0F, 0x0F };
            KEY._colidx = 0;
            LOG.@out("KEY", "Reset.");
        }

        public static int rb()
        {
            switch (KEY._colidx)
            {
                case 0x00: return 0x00;
                case 0x10: return KEY._keys[0];
                case 0x20: return KEY._keys[1];
                default: return 0x00;
            }
        }

        public static void wb(int v)
        {
            KEY._colidx = v & 0x30;
        }

        public static void keydown(int keyCode)
        {
            switch (keyCode)
            {
                case 39: KEY._keys[1] &= 0xE; break;
                case 37: KEY._keys[1] &= 0xD; break;
                case 38: KEY._keys[1] &= 0xB; break;
                case 40: KEY._keys[1] &= 0x7; break;
                case 90: KEY._keys[0] &= 0xE; break;
                case 88: KEY._keys[0] &= 0xD; break;
                case 32: KEY._keys[0] &= 0xB; break;
                case 13: KEY._keys[0] &= 0x7; break;
            }
        }

        public static void keyup(int keyCode)
        {
            switch (keyCode)
            {
                case 39: KEY._keys[1] |= 0x1; break;
                case 37: KEY._keys[1] |= 0x2; break;
                case 38: KEY._keys[1] |= 0x4; break;
                case 40: KEY._keys[1] |= 0x8; break;
                case 90: KEY._keys[0] |= 0x1; break;
                case 88: KEY._keys[0] |= 0x2; break;
                case 32: KEY._keys[0] |= 0x5; break;
                case 13: KEY._keys[0] |= 0x8; break;
            }
        }
    }
}