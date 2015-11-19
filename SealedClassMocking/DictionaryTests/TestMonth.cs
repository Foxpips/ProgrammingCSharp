using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ProgrammingTests.DictionaryTests
{
    public class TestMonth
    {
        [Test]
        public void GetMonth()
        {
            DateTime? source = DateTime.Now;

            var dictionary = new Dictionary<int, string>
            {
                {1, "Jan"},
                {2, "Feb"},
                {3, "Mar"},
                {4, "Apr"},
                {5, "May"},
                {6, "Jun"},
                {7, "Jul"},
                {8, "Aug"},
                {9, "Sep"},
                {10, "Oct"},
                {11, "Nov"},
                {12, "Dec"}
            };

            string month;
            var shortMonth = dictionary.TryGetValue(source.Value.Date.Month, out month);
            month += " " + source.Value.Day;

            Console.WriteLine(month);
        }

        [Test]
        public void Method_Date_Result()
        {
            var dateTime = DateTime.Now;

            var s = dateTime.ToString("MMM dd");


            Console.WriteLine(s);
        }

        [Test]
        public void DateTime_New()
        {



        }
    }
}