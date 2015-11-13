using System;
using System.Threading;
using NUnit.Framework;

namespace MSExamTests.Chapter1
{
    public class ThreadPooler
    {
        public void PoolThread(int myint)
        {
            ThreadPool.QueueUserWorkItem(s =>
            {
                //Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine(myint + " Working on a thread from threadpool");
            });
        }
        public void SecondPoolThread(int myint)
        {
            ThreadPool.QueueUserWorkItem((o) =>
            {
                for (int i = 0; i < myint; i++)
                {
                    Console.WriteLine(myint + " second pool thread");
                }
                //Thread.Sleep(TimeSpan.FromSeconds(2));
            });
        }
    }


    public class TestThreadPooler
    {
        [Test]
        public void TestPooler_PoolThreads_Result()
        {
            var threadPooler = new ThreadPooler();
            threadPooler.PoolThread(1);
            threadPooler.PoolThread(2);
            threadPooler.PoolThread(3);

            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine("Main thread pool shouldn't be available");
            }
            threadPooler.PoolThread(3);
            threadPooler.PoolThread(3);
            threadPooler.PoolThread(3);
            threadPooler.PoolThread(3);

            threadPooler.SecondPoolThread(2);
            threadPooler.SecondPoolThread(2);
            threadPooler.SecondPoolThread(2);

            int max;
            int completion;
            int available;
          ThreadPool.GetMaxThreads(out max,out completion);
            ThreadPool.GetAvailableThreads(out available,out completion);

            Console.WriteLine(max);
            Console.WriteLine(completion);
            Console.WriteLine(available);
            Console.WriteLine("finished");
        }
    }
}