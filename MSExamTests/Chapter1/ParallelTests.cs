using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using NUnit.Framework;

namespace MSExamTests.Chapter1
{
    public class ParallelTests
    {
        [Test]
        public void Method_Scenario_Result()
        {
//            Parallel.For(0, 10, i => { Thread.Sleep(1000); });
            var numbers = Enumerable.Range(0, 10).ToList();


//            numbers.Each(i =>
//            {
//                Thread.Sleep(1000);
//                Console.WriteLine(i);
//            });

            Parallel.ForEach(numbers, i =>
            {
                Thread.Sleep(1000);
                Console.WriteLine(i);
            });
        }
    }
}