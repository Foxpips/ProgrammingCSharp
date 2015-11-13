using System;
using NUnit.Framework;

namespace MSExamTests.Chapter2._2._19
{
    public class BoxingTests
    {
        [Test]
        public void Boxing_structs_Result()
        {
            double s = 123.1;
            Console.WriteLine(s);

            object o = s; // Box the double.
            Console.WriteLine(o);

            int i = (int) s; // Perfectly legal.
            Console.WriteLine(i);

            int j = (int) (double) o; // Perfectly legal
            Console.WriteLine(j);

            try
            {
                int k = (int)o; // Invalid cast exception?! Why? Must be unboxed to exact type it was boxed as
            
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(@"Always catch specific exceptions!!");
            }
            
            //Boxed
            IFormattable x = 3;
        }
    }
}