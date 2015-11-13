using System;
using NUnit.Framework;

namespace SealedClassMocking.SmallestNumberTest
{
    public class BuildLowestNumTests
    {
        // A recursive function that removes 'n' characters from 'str'
        // to store the smallest possible number in 'res'
        public void BuildLowestNumberRec(string str, int n, ref string res)
        {
            // If there are 0 characters to remove from str,
            // append everything to result
            if (n == 0)
            {
                res += str;
                return;
            }

            var len = str.Length;

            // If there are more characters to remove than string
            // length, then append nothing to result
            if (len <= n)
                return;

            // Find the smallest character among first (n+1) characters
            // of str.
            var minIndex = 0;
            for (var i = 1; i <= n; i++)
            {
                if (str[i] < str[minIndex])
                {
                    minIndex = i;
                }
            }
            // Append the smallest character to result


            res += (str[minIndex]);

            // substring starting from minIndex+1 to str.length() - 1.
            var newStr = str.Substring(minIndex + 1, len - (minIndex + 1));

            // Recur for the above substring and n equals to n-minIndex
            BuildLowestNumberRec(newStr, n - minIndex, ref res);
        }

        // A wrapper over buildLowestNumberRec()
        private void BuildLowestNumber(string str, int n)
        {
            var res = "";

            // Note that result is passed by reference
            BuildLowestNumberRec(str, n, ref res);

            Console.WriteLine(res);
        }

        // Driver program to test above function
        [Test]
        public void MainTest()
        {
            BuildLowestNumber("28971", 2); //271
            BuildLowestNumber("237489", 3); //234
            BuildLowestNumber("9438958", 4); //358
            BuildLowestNumber("18437562", 5); //132
            BuildLowestNumber("18437562", 3); //13562
            BuildLowestNumber("18437562", 2); //137562
            BuildLowestNumber("18437562", 1); //1437562
        }
    }
}