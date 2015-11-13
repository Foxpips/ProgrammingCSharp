using System;
using System.Threading;
using NUnit.Framework;

namespace MSExamTests.Chapter1
{
    public class ThreadLoop
    {
        [ThreadStatic]
        public static int _number = 0;

        [Test]
        public void Test_Thread_Result()
        {
            var stopped = true;

            var thread = new Thread((name) =>
            {
                for (int i = 0; i < 4; i++)
                {
                    //if (stopped)
                    //{
                    //    break;
                    //}
                    Console.WriteLine(++_number);
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    Console.WriteLine("Thread loop number {0}", i);
                }
                Console.WriteLine("Hello " + name);
            });

            thread.Start("Simon");

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(++_number);
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine("loop number {0}", i);
            }
            Console.WriteLine("Hello Mickael");

            thread.Join();
        }
    }
}