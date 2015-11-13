using System;
using NUnit.Framework;

namespace MSExamTests.Chapter2._2._24
{
    internal class Money
    {
        public Money(decimal amount)
        {
            Amount = amount;
        }

        public decimal Amount { get; set; }

         public static explicit operator int(Money money)
        {
            return (int) money.Amount;
        }
    }


    public class TestCasting
    {
        [Test]
        public void Method_Scenario_Result()
        {
            decimal d = 12.6m;
            float f = 18.6f;
            var money = new Money(d);

//            decimal amount = money;

            var i = (int) money;
            Console.WriteLine(i);

//            Console.WriteLine(amount);
        }
    }
}