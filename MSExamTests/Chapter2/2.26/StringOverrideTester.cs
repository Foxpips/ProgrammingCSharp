using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MSExamTests.Chapter2._2._26
{
    public class StringOverrideTester
    {
        [Test]
        public void StringFormat_Scenario_Result()
        {
            var myList = new List<BillingRecord>();

            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                myList.Add(new BillingRecord
                {
                    RowCount = random.Next(100),
                    Name = "Annual Report",
                    Date = DateTime.Now.AddDays(random.Next(10))
                });
            }

            myList.ForEach(Console.WriteLine);
        }
    }

    public class BillingRecord
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int RowCount { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0} Date: {1} RowCount: {2}", Name, Date.ToString("d"), RowCount);
        }
    }
}