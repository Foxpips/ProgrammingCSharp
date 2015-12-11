using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace MeasureupTests
{
    public class CollectionTests
    {
        static int _x2;

        [Test]
        public void Method_Scenario_Result()
        {
            var list = new List<string> {"hello", "world"};
            var s = list[0];
            Console.WriteLine(s);


           
            Interlocked.Increment(ref _x2);


            var dictionary = new Dictionary<int, string> {{0, "Hello"}, {2, "World"}};
            var s1 = dictionary[0];


            var dateTime = new DateTime(1988,10,10);
            var dateTimes = new List<DateTime> { new DateTime(1988, 10, 10), new DateTime(1988, 10, 10), new DateTime(1987, 12, 29) };


            var enumerable = from time in dateTimes group time by time.Date into grouping select new {Date = grouping, Count = grouping.Count()};
            var enumerable2 = dateTimes.GroupBy(x => x.Date).Select(y => new {Date = y, Count = y.Count()}).ToList();


            Console.WriteLine(s1);
        }
    }
}