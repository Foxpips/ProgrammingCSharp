using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SealedClassMocking.Comparers
{
    public class CountyComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x.Equals(y, StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }
            var xhasDigits = x.Any(char.IsDigit);
            var yhasDigits = y.Any(char.IsDigit);

            string firstWord = "", secondWord = "";
            var length = y.IndexOf(" ", StringComparison.Ordinal);
            var indexOf = x.IndexOf(" ", StringComparison.Ordinal);

            if (length != -1 && indexOf != -1)
            {
                firstWord = x.Substring(0, indexOf);
                secondWord = y.Substring(0, length);
            }

            if (xhasDigits && yhasDigits && firstWord.Equals(secondWord, StringComparison.OrdinalIgnoreCase))
            {
                return SortByDigits(x, y);
            }

            return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
        }

        private static int SortByDigits(string x, string y)
        {
            if (x[0] > y[0])
            {
                return 1;
            }
            int xInt;
            int yInt;

            if (Int32.TryParse(Regex.Match(x, @"\d+").Value, out xInt) &&
                Int32.TryParse(Regex.Match(y, @"\d+").Value, out yInt))
            {
                if (xInt > yInt)
                {
                    return 1;
                }
                if (xInt == yInt)
                {
                    return 0;
                }
                return -1;
            }
            return 0;
        }
    }
}