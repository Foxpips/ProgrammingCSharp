using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace MSExamTests.Chapter1._2
{
    public class PLinq
    {

        [Test]
        public void Ordered_Sequential_Result()
        {
            var enumerable = Enumerable.Range(0, 20);
            
            var parallelQuery = enumerable.AsParallel().Where(i => i % 2 == 0).AsSequential();
            foreach (var source in parallelQuery.Take(5))
            {
                Console.WriteLine(source);
            }
        }

        [Test]
        public void Method_Scenario_Result()
        {
            var ints = new List<int>() {10, 9, 8, 7, 6, 5, 4, 3, 2, 1}.ToList();
            
            foreach (var i in ints)
            {
                Console.WriteLine(i);
            }
        }

        [Test]
        public void PLinq_One_Test()
        {
            var numbers = Enumerable.Range(0, 10).ToList();
            var numbers2 = Enumerable.Range(0, 10).ToList();

            var parallelList = numbers.AsParallel().Where(i => i%2 == 0).ToArray();

            var array = parallelList.ToArray();
            
            foreach (var i in array)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            //var array = parallelList.ToArray();
            //foreach (var i in array)
            //{
            //    Console.WriteLine(i);
            //}


            Console.WriteLine();

            var synchronousList = numbers2.Where(i => i%2 == 0).ToArray();
            foreach (var i in synchronousList)
            {
                Console.WriteLine(i);
            }
        }
    }
}