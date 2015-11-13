using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Timer = SealedClassMocking.StringConcatenationProfiling.Timer;

namespace MSExamTests.Chapter1._2
{
    public class PLinqForAll
    {
        [Test]
        public void ForAll_Scenario_Result()
        {
            var numbers = Enumerable.Range(0, 200);

            ParallelQuery<int> parallelQuery = numbers.AsParallel().AsOrdered().Where(i => i%2 == 0);

            //foreach (var i in parallelQuery)
            //{
            //    Console.WriteLine(i);
            //}

            Timer.Time(() => { Parallel.ForEach(parallelQuery, Console.Write); }, "ForEach",100);
            Timer.Time(() => { parallelQuery.ForAll(Console.Write); }, "ForAll",100);


            Console.WriteLine(@"Finished");
        }
    }
}