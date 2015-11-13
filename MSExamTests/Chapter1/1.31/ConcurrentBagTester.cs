using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MSExamTests.Chapter1._1._31
{
    public class ConcurrentBagTester
    {
        [Test]
        public void TestPeeking_Scenario_Result()
        {
            ConcurrentBag<object> bag = new ConcurrentBag<object> { 42, 21, 66, 99, 1 ,"joey"};
            object result;


            bag.Add("Mikey");
            if (bag.TryTake(out result))
            {
                Console.WriteLine(result);
            }
            if (bag.TryPeek(out result))
            {
                Console.WriteLine(@"There is a next item: {0}", result);
            }
            if (bag.TryPeek(out result))
            {
                Console.WriteLine(@"There is a next item: {0}", result);
            }
        }

        [Test]
        public void TestOrderIteration()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            Task.Run(() =>
            {
                bag.Add(42);
                Thread.Sleep(1000);
                bag.Add(21);
            });
            Task.Run(() =>
            {
                Thread.Sleep(900);
                foreach (int i in bag)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(200);
                    bag.Add(100);
                }
            }).Wait();


            Console.WriteLine();
            // Displays
            // 42 
        }
    }
}