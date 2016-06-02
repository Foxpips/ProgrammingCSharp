using System;
using System.Collections.Generic;
using NUnit.Framework;
using ProgrammingTests.Extensions;

namespace ProgrammingTests
{
    public class SortSelfTests
    {
        [Test]
        public void Method_Scenario_Result()
        {
            var list = new List<string> {"Simon", "Andrew"};
            list.SortSelf().Each(Console.WriteLine);
                
            list.Each(Console.WriteLine);
        }
    }
}