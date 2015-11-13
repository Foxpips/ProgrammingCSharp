using System;
using System.Linq;

namespace AggregateExceptionConsole
{
    public static class Program
    {
        public static void Main2()
        {
            var numbers = Enumerable.Range(0, 20);
            try
            {
                var parallelResult = numbers.AsParallel().Where(i => IsEven(i));
                parallelResult.ForAll(e => Console.WriteLine(e));
            }
            catch (AggregateException e)
            {
                Console.WriteLine("There where {0} exceptions",e.InnerExceptions.Count);
            }
            Console.Read();
        }

        public static bool IsEven(int i)
        {
            if (i%10 == 0) 
                throw new ArgumentException(i.ToString());
            return i%2 == 0;
        }
    }
}