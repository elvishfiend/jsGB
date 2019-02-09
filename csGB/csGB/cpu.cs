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
    public static partial class cpu
    {
        public struct clock { public int m; }
        public static clock _clock = new clock();

        public static int _halt = 0;
        public static int _stop = 0;

        public static void reset()
        {
            cpu._r.a = 0; cpu._r.b = 0; cpu._r.c = 0; cpu._r.d = 0; cpu._r.e = 0; cpu._r.h = 0; cpu._r.l = 0; cpu._r.f = 0;
            cpu._r.sp = 0; cpu._r.pc = 0; cpu._r.i = 0; cpu._r.r = 0;
            cpu._r.m = 0;
            cpu._halt = 0; cpu._stop = 0;
            cpu._clock.m = 0;
            cpu._r.ime = 1;
            LOG.@out("cpu", "Reset.");
        }

        public static void exec()
        {
            cpu._r.r = (cpu._r.r + 1) & 127;
            cpu._map[MMU.rb(cpu._r.pc++)]();
            cpu._r.pc &= 65535;
            cpu._clock.m += cpu._r.m;
        }
    }
};