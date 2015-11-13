using System;
using System.Threading;
using NUnit.Framework;

namespace MSExamTests.Chapter1
{
    public class ThreadLocalData
    {
        public static ThreadLocal<int> Field = new ThreadLocal<int>(() => Thread.CurrentThread.ManagedThreadId);
        public static int Fieldbasic = Thread.CurrentThread.ManagedThreadId;
        [Test]
        public static void Main()
        {
            new Thread(() =>
            {
                var threadId = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine("1 thread 1 " + threadId);
                Console.WriteLine("2 thread 1 " + Field.Value);
                Console.WriteLine("3 thread 1 " + Fieldbasic);

                for (int x = 0; x < Field.Value; x++)
                {
                    //Console.WriteLine("Thread A: {0}", x);
                }
            }).Start();
            var thread2 = new Thread(() =>
            {
                var threadId = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine("1 thread 2 " + threadId);
                Console.WriteLine("2 thread 2 " + Field.Value);
                Console.WriteLine("3 thread 2 " + Fieldbasic);
                for (int x = 0; x < Field.Value; x++)
                {
                    //Console.WriteLine("Thread B: {0}", x);
                }
            });
            thread2.Start();
            thread2.Join();


            //Console.ReadKey();
        }
    }
}