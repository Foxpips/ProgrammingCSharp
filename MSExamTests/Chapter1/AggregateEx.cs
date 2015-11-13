using System;
using System.Linq;
using NUnit.Framework;

namespace MSExamTests.Chapter1
{
    public static class AggregateEx
    {
        [Test]
        public static void GetEvens()
        {
            var numbers = Enumerable.Range(0, 20);
            try
            {
                var parallelResult = numbers.AsParallel().Where(IsEven);
                parallelResult.ForAll(Console.WriteLine);
            }
            catch (AggregateException e)
            {
                Console.WriteLine(@"There were {0} exceptions", e.InnerExceptions.Count);
            }
        }

        public static  bool IsEven(int i)
        {
            if (i%10 == 0) throw new ArgumentException("i");
            return i%2 == 0;
        }
    }
}