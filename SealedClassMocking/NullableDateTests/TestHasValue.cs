using System;
using NUnit.Framework;

namespace SealedClassMocking.NullableDateTests
{
    public class TestHasValue
    {
        [Test]
        public void Method_Scenario_Result()
        {
            var claim = new Claim();
            Console.WriteLine(claim.MyDate.HasValue ? "I have a value" : "Im null!");
        }

        public class Claim
        {
            public DateTime? MyDate { get; set; }
        }

        [Test]
        public void DateTime_Scenario_Result()
        {
            var dateTime = new DateTime(2015, 10, 12);

            Console.WriteLine(DateTime.Now);
            Console.WriteLine(DateTime.Today);

            if (dateTime > DateTime.Today)
            {
                Console.WriteLine("Hello");
            }
        }
    }
}