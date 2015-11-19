using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MSExamTests.Chapter1._1._31
{
    public class ConcurrentClassTesters
    {
        [Test]
        public void Method_Scenario_Result()
        {
            try
            {
                var stack = new ConcurrentStack<int>();
//            stack.PushRange(new[] { 1, 2, 3 });

                stack.Push(1);
                stack.Push(2);
                stack.Push(3);

                var values = new int[3];

                var run = Task.Run(() =>
                {
                    int counter = stack.Count;
                    for (int i = 0; i < counter; i++)
                    {
                        int popped;
                        var pop = stack.TryPop(out popped);
                        Thread.Sleep(1000);
                        Console.WriteLine(popped);
                    }
                });

                var task = Task.Run(() =>
                {
                    stack.Push(4);
                    int popped2;
                    stack.TryPop(out popped2);
                    stack.TryPop(out popped2);
                    stack.TryPop(out popped2);
                    stack.TryPop(out popped2);
                
                });

                Task.WaitAll(run,task);
            }
            catch (AggregateException ex)
            {
                foreach (var innerException in ex.InnerExceptions)
                {
                    Console.WriteLine(innerException.Message);
                }
            }



        }
    }
}