using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ProgrammingTests
{
    public class MailingListTest
    {
        [Test]
        public void Method_Scenario_Result()
        {
            var mailingLists = new List<MailingList> { new MailingList {Address = "MyHouse", City = "City1"} };

            var enumerable = mailingLists.Where(x => x.Address != "").Select(I => new MailingList { Name = I.Name != null ? I.Name : "Our Neightbors", Address = I.Address, City = I.City });

            foreach (var mailingList in enumerable)
            {
                Console.WriteLine(mailingList.Name);
                Console.WriteLine(mailingList.Address);
                Console.WriteLine(mailingList.City);
            }
        }
    }

    public class MailingList
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}