using System;
using System.Diagnostics;

namespace ProgrammingTests.StringConcatenationProfiling
{
    public class Timer
    {
        internal static void Time(Func<string> action,string methodName)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            // Make sure it's JITted
            action();
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 10000000; i++)
            {
                action();
            }
            sw.Stop();
            Console.WriteLine(" {0}: {1} millis", methodName,
                (long) sw.Elapsed.TotalMilliseconds);
        }

        public static void Time(Action action, string methodName, int iterations = 10000000)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            // Make sure it's JITted
            action();
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                action();
            }
            sw.Stop();
            Console.WriteLine(" {0}: {1} millis", methodName,
                (long)sw.Elapsed.TotalMilliseconds);
        }
    }
}