using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using NUnit.Framework;

namespace ProgrammingTests.SmallestNumberTest
{
    public class ComplexLetter
    {
        public ComplexLetter(char letter, int position)
        {
            Letter = letter;
            Position = position;
        }

        public char Letter { get; set; }
        public int Position { get; set; }
    }

    public class SmallestNumberTests
    {
        public string GetSmallestNumber(string str, int n)
        {
            var stringBuilder = new StringBuilder();
            var orderByDescending = str.ToCharArray().OrderBy(c => c);
            foreach (var item in orderByDescending)
            {
                stringBuilder.Append(item.ToString());
            }
            var s = stringBuilder.ToString();

            var remove = s.Remove(str.Length - n);

            return remove;
        }

        public void CalculateSmallestNumber(string str, int n)
        {
            char[] mychar = str.ToCharArray();
            var smallest = mychar.FirstOrDefault();
            var list = new List<ComplexLetter>();


            var maxTrim = str.Length - n;

            while (list.Count < maxTrim)
            {
                StringBuilder stringBuilder = new StringBuilder(str);
                var traverseString = TraverseString(str, smallest);
                list.Add(traverseString);
                stringBuilder[traverseString.Position] = ' ';
                str = stringBuilder.ToString().Replace(" ", string.Empty);
                smallest = str.ToCharArray().FirstOrDefault();
            }

            Console.WriteLine();

            var orderedEnumerable = list.OrderBy(letter => letter.Position);
            orderedEnumerable.Each(letter => Console.WriteLine(letter.Letter + " " + letter.Position));
        }

        private static ComplexLetter TraverseString(string str, char smallest)
        {
            ComplexLetter comp = new ComplexLetter(str[0], 0);

            for (var curr = 0; curr < str.Length; curr++)
            {
                //                Console.WriteLine(str[curr]);
                if (str[curr] < smallest)
                {
                    comp = new ComplexLetter(str[curr], curr);
                    smallest = str[curr];
                }
            }

            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            return comp;
        }

        //        [Test]
        //        public void Method_Scenario_Result()
        //        {
        //            Console.WriteLine(GetSmallestNumber("72388", 2));
        //        }

        [Test]
        public void Calc_Scenario_Result()
        {
            CalculateSmallestNumber("28971", 2);
            CalculateSmallestNumber("237489", 3);
            CalculateSmallestNumber("9438958", 4);
            CalculateSmallestNumber("18437562", 5);
            CalculateSmallestNumber("18437562", 3); //13562 but 14352
            CalculateSmallestNumber("18437562", 2);
            CalculateSmallestNumber("18437562", 1);
        }
    }
}