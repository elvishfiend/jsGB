using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csGB
{
    public static class GB
    {
        static GB()
        {
            timer.Elapsed += Timer_Elapsed;
        }

        private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Z80._r.ime != 0 && MMU._ie != 0 && MMU._if != 0)
            {
                Z80._halt = false; Z80._r.ime = 0;

                if (((MMU._ie & 1) != 0) && ((MMU._if & 1) != 0))
                {
                    MMU._if &= 0xFE; Z80._ops.RST40();
                }
            }
            else
            {
                if (Z80._halt) { Z80._r.m = 1; }
                else
                {
                    Z80._r.r = (Z80._r.r + 1) & 127;
                    Z80._map[MMU.rb(Z80._r.pc++)]();
                    Z80._r.pc &= 65535;
                }
            }

            Z80._clock.m += Z80._r.m; Z80._clock.t += (Z80._r.m * 4);
            //GPU.checkline();
        }

        public static void ResetAll()
        {
            LOG.reset();
            //GPU.reset();
            MMU.reset();
            Z80.reset();
            KEY.reset();
            TIMER.reset();

            Z80._r.pc = 0x100;
            MMU._inbios = true;
            Z80._r.sp = 0xFFFE;
            Z80._r.h = 0x01;
            Z80._r.l = 0x4D;
            Z80._r.c = 0x13;
            Z80._r.e = 0xD8;
            Z80._r.a = 1;
        }

        public static void Run()
        {
            Z80._stop = false;
            //timer.Start();
            while (!Z80._stop)
            {
                Timer_Elapsed(null, null);
            }

        }

        public static System.Timers.Timer timer = new System.Timers.Timer()
        {
            AutoReset = true,
            Interval = 20,
        };

    }
}
