using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationProfiling
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string concat = "";
            Console.ReadLine();
            for (int i = 0; i < 1000; i++)
            {
                concat += string.Concat("Hello ", "Simon ", "How ", "are ", "you?");
//                var concat = string.Format("{0}{1}{2}{3}{4}", "Hello ", "Simon ", "How ", "are ", "you?");
                Console.WriteLine(concat);
            }
            Console.ReadLine();
        }
    }
}