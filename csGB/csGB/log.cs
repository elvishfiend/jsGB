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
            if (string.IsNullOrWhiteSpace(str))
                return;

            if (OnLog != null)
            {
                var t = DateTime.Now;
                var ts = t - LOG._start;

                var message = "{" + ts.TotalMilliseconds + "ms} [" + module + "] " + str;
                OnLog?.Invoke(message);
            }
        }

        public static void @out(string module, string format, params object[] args)
        {
            if (string.IsNullOrWhiteSpace(format))
                return;

            if (OnLog != null)
            {
                var str = string.Format(format, args);

                var t = DateTime.Now;
                var ts = t - LOG._start;

                var message = "{" + ts.TotalMilliseconds + "ms} [" + module + "] " + str;
                OnLog?.Invoke(message);
            }
        }

        public delegate void LogEvent(string log);

        public static event LogEvent OnLog;

        public static LogEvent ConsoleLogger = (message) => Console.WriteLine(message);
    }
}
