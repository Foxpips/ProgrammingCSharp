using System;
using NUnit.Framework;

namespace SealedClassMocking.DecimalTests
{
    public class DecimalTester
    {
        [Test]
        public void Decimal_Scenario_Result()
        {
            double progress = 0.385902093842039;

            Console.WriteLine(progress.ToString("00"));
        } 
    }
}