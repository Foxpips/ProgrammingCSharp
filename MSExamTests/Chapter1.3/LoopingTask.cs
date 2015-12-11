using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MSExamTests.Chapter1._3
{
    public class LoopingTask
    {
        private readonly object _myLock = new object();
        private string _type;

        public string Type
        {
            get { return _type; }
            set
            {
                lock (_myLock)
                {
                    _type = value;
                }
            }
        }

        [Test]
        public void Method_Scenario_Result()
        {
            int n = 0;
            object _lock = new object();

            var up = Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(@"First Before lock");
                    lock (_lock)
                    {
                        n++;
                        Console.WriteLine(@"First Into lock" + n);
                        Thread.Sleep(TimeSpan.FromSeconds(5));
                    }
                }
                Console.WriteLine(@"First After lock");
            });

            var up2 = Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(@"Second Before lock");
                    lock (_lock)
                    {
                        n--;
                        Console.WriteLine(@"Second Into lock " + n);
                    }
                    Console.WriteLine(@"Second After lock");
                }
            });

            Task.WaitAll(up, up2);
            Console.WriteLine(n);
        }
    }
}