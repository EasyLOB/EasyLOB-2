using EasyLOB.Log;
using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void NLogDemo()
        {
            Console.WriteLine("\nNLog Demo");

            try
            {
                /*
                 * Fatal
                 * Error
                 * Warning
                 * Info
                 * Debug
                 * Trace
                 * Off
                 */

                int d = DateTime.Today.Day;
                int ym = DateTime.Today.Year * 100 + DateTime.Today.Month;

                LogManager logManager = new LogManager();

                logManager.Trace("Sample trace message");
                logManager.Debug("Sample debug message");
                logManager.Information("Sample informational message");
                logManager.Warning("Sample warning message");
                logManager.Error("Sample error message");
                logManager.Fatal("Sample fatal error message");

                logManager.Trace("Sample trace message, d={0}, ym={1}", d, ym);
                logManager.Debug("Sample debug message, d={0}, ym={1}", d, ym);
                logManager.Information("Sample informational message, d={0}, ym={1}", d, ym);
                logManager.Warning("Sample warning message, d={0}, ym={1}", d, ym);
                logManager.Error("Sample error message, d={0}, ym={1}", d, ym);
                logManager.Fatal("Sample fatal error message, d={0}, ym={1}", d, ym);
            }
            catch (Exception exception)
            {
                WriteException(exception);
            }
        }
    }
}