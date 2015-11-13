using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SealedClassMocking.Comparers;
using SealedClassMocking.Extensions;

namespace SealedClassMocking.TimeSpanTests
{
    public class TestOrderStringsAndNumbers
    {
        private IEnumerable<string> _countyList;

        [SetUp]
        public void SetUp()
        {
            _countyList = new List<string>
            {
                "Dublin 20",
                "Louth",
                "Meath 14",
                "Meath 2",
                "Dublin 18",
                "Dublin 2",
                "Wicklow",
                "Cavan",
                "Laois",
                "Dublin 1",
                "Dublin 10",
                "Clare 5",
                "Clare 1",
            };
        }

//        [Test]
//        public void Order_StringsAndNumbers_Order()
//        {
//            var list = new List<string> {"Dublin 20", "Dublin 18", "Dublin 2", "Dublin 1", "Dublin 10"};
//            list.Sort((s, s1) =>
//            {
//                var first = Convert.ToInt32(s.Substring(6, s.Length - 6).Trim());
//                var second = Convert.ToInt32(s1.Substring(6, s1.Length - 6).Trim());
//
//                return first > second ? 1 : -1;
//            });
//
//            foreach (var s in list)
//            {
//                Console.WriteLine(s);
//            }
//        }

        [Test]
        public void Order_IEnumerable_Result()
        {
            var orderedEnumerable = _countyList.OrderBy(s => s, new ComparerTester());

            orderedEnumerable.Each(Console.WriteLine);
        }

        [Test]
        public void CountyComparer_Scenario_Result()
        {
            var orderedEnumerable = _countyList.OrderBy(item => item, new CountyComparer());
            orderedEnumerable.Each(Console.WriteLine);
        }
    }

    public class ComparerTester : IComparer<string>
    {
        public int Compare(string s, string s1)
        {
            if (!s.Any(char.IsDigit) || !s1.Any(char.IsDigit))
            {
                return string.Compare(s, s1, StringComparison.OrdinalIgnoreCase);
            }

            var startIndex = s.IndexOf(" ", StringComparison.Ordinal);
            var startIndex2 = s1.IndexOf(" ", StringComparison.Ordinal);

            var first = Convert.ToInt32(s.Substring(startIndex, s.Length - startIndex).Trim());
            var second = Convert.ToInt32(s1.Substring(startIndex2, s1.Length - startIndex2).Trim());


            if (first == second)
            {
                return 0;
            }

            return first > second ? 1 : -1;
        }
    }
}