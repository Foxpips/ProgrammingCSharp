using System;
using NUnit.Framework;

namespace ProgrammingTests.DateTests
{
    public class TestDates
    {
        [Test]
        public void Method_Scenario_Result()
        {
            var s = (10 + "/" + 10 + "/" + 2010);
            DateTime validDate;
            var isValidDate = DateTime.TryParse(s, out validDate);

            Console.WriteLine(isValidDate);
            if (isValidDate)
            {
                Console.WriteLine(validDate);
            }
        }

        [Test]
        public void default_int_Result()
        {
            const string @true = 1==1 ? "true" : "false";

            Console.WriteLine(@true);

            Console.WriteLine(default(int)); 
        }


        [Test]
        public void Date_Month_Thirteen()
        {
            var dateTime = new DateTime(2015, 13, 10).ToString("d");

            Console.WriteLine(dateTime);
        }
    }
}