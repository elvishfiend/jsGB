using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csGB
{
    public static class LOG
    {
        public static DateTime _start;

        public static void reset()
        {
            LOG._start = DateTime.Now;
        }

        public static void @out(string module, string str)
        {
            var t = DateTime.Now;
            var ts = t - LOG._start;
            Console.WriteLine("{" + ts.Milliseconds + "ms} [" + module + "] " + str);
        }
    }
}
