using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ProgrammingTests.TimeSpanTests
{
    public sealed class RecurrentTime : RecurrentTimeBase
    {
        public TimeSpan TimeSpan { get; set; }

        public RecurrentTime()
        {
            Descriptions = new Dictionary<TimeSpan, string>
            {
                {TimeSpan.Daily, "None"},
                {TimeSpan.Monthly, "Every Month"}
            };
        }

        public string GetDescription()
        {
            return Descriptions[TimeSpan];
        }
    }


    public class TestEnums
    {
        [Test]
        public void Method_Scenario_Result()
        {
            var recurrentTime = new RecurrentTime {TimeSpan = TimeSpan.Daily};
            var description = recurrentTime.GetDescription();
            Console.WriteLine(description);
        }
    }
}