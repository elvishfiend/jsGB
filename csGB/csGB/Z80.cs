/**
 * jsGB: cpu core
 * Imran Nazar, May 2009
 * Notes: This is a GameBoy cpu, not a cpu. There are differences.
 * Bugs: If PC wraps at the top of memory, this will not be caught until the end of an instruction
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csGB
{
    public static partial class Z80
    {
        public struct clock {
            public int m;
            public int t;
        }
        public static clock _clock = new clock();

        public static int _halt = 0;
        public static int _stop = 0;

        public static void reset()
        {
            Z80._r.a = 0; Z80._r.b = 0; Z80._r.c = 0; Z80._r.d = 0; Z80._r.e = 0; Z80._r.h = 0; Z80._r.l = 0; Z80._r.f = 0;
            Z80._r.sp = 0; Z80._r.pc = 0; Z80._r.i = 0; Z80._r.r = 0;
            Z80._r.m = 0;
            Z80._halt = 0; Z80._stop = 0;
            Z80._clock.m = 0;
            Z80._r.ime = 1;
            LOG.@out("cpu", "Reset.");
        }

        public static void exec()
        {
            Z80._r.r = (Z80._r.r + 1) & 127;
            Z80._map[MMU.rb(Z80._r.pc++)]();
            Z80._r.pc &= 65535;
            Z80._clock.m += Z80._r.m;
        }
    }
};