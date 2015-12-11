using System;
using System.Threading;
using NUnit.Framework;

namespace MSExamTests.Chapter1._3
{
    internal static class StrangeBehavior
    {
        // As you'll see later, mark this field as volatile to fix the problem
        private static bool _sStopWorker;

        [Test]
        public static void Main()
        {
            Console.WriteLine(@"Main: letting worker run for 5 seconds");
            var t = new Thread(Worker);
            t.Start();
            Thread.Sleep(5000);
            _sStopWorker = true;
            Console.WriteLine(@"Main: waiting for worker to stop");
            t.Join();
        }

        private static void Worker(object o)
        {
            var x = 0;
            while (!_sStopWorker) x++;
            Console.WriteLine(@"Worker: stopped when x={0}", x);
        }
    }
}