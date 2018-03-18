using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csGB
{
    public static class TIMER
    {
        public static int _div = 0;
        public static int _sdiv = 0;
        public static int _tma = 0;
        public static int _tima = 0;
        public static int _tac = 0;

        public static class _clock
        {
            public static int main = 0;
            public static int sub = 0;
            public static int div = 0;
        }

        public static void reset()
        {
            TIMER._div = 0;
            TIMER._sdiv = 0;
            TIMER._tma = 0;
            TIMER._tima = 0;
            TIMER._tac = 0;
            TIMER._clock.main = 0;
            TIMER._clock.sub = 0;
            TIMER._clock.div = 0;
            //LOG.out('TIMER', 'Reset.');
        }

        public static void step()
        {
            TIMER._tima++;
            TIMER._clock.main = 0;
            if (TIMER._tima > 255)
            {
                TIMER._tima = TIMER._tma;
                MMU._if |= 4;
            }
        }

        public static void inc()
        {
            var oldclk = TIMER._clock.main;

            TIMER._clock.sub += Z80._r.m;
            if (TIMER._clock.sub > 3)
            {
                TIMER._clock.main++;
                TIMER._clock.sub -= 4;

                TIMER._clock.div++;
                if (TIMER._clock.div == 16)
                {
                    TIMER._clock.div = 0;
                    TIMER._div++;
                    TIMER._div &= 255;
                }
            }

            if ((TIMER._tac & 4) != 0)
            {
                switch (TIMER._tac & 3)
                {
                    case 0:
                        if (TIMER._clock.main >= 64) TIMER.step();
                        break;
                    case 1:
                        if (TIMER._clock.main >= 1) TIMER.step();
                        break;
                    case 2:
                        if (TIMER._clock.main >= 4) TIMER.step();
                        break;
                    case 3:
                        if (TIMER._clock.main >= 16) TIMER.step();
                        break;
                }
            }
        }

        public static int rb(int addr)
        {
            switch (addr)
            {
                case 0xFF04: return TIMER._div;
                case 0xFF05: return TIMER._tima;
                case 0xFF06: return TIMER._tma;
                case 0xFF07: return TIMER._tac;
                    default: return 0;
            };
        }

        public static void wb(int addr, int val)
        {
            switch (addr)
            {
                case 0xFF04: TIMER._div = 0; break;
                case 0xFF05: TIMER._tima = val; break;
                case 0xFF06: TIMER._tma = val; break;
                case 0xFF07: TIMER._tac = val & 7; break;
            };
        }
    }
}
