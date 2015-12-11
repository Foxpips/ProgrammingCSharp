using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ProgrammingTests
{
    interface IOrder
    {
        void Process();
    }

    public class AmazonOrder : IOrder
    {
        void IOrder.Process()
        {
            Console.WriteLine("Processing Amazon Order");
        }

        public void GetOrderDetails()
        {
            Console.WriteLine("info");
        }
    }

    public class EbayOrder : IOrder
    {
        public void Process()
        {
            Console.WriteLine("Processing Ebay Order");
        }

        public void GetOrderDetails()
        {
            Console.WriteLine("info");
        }
    }

    public class TestOrder
    {

        [Test]
        public void Test_Scenario_Result()
        {
            IOrder amazonOrder = new AmazonOrder();
            amazonOrder.Process();
        }

        [Test]
        public void Method_Scenario_Result()
        {
            var orders = new List<IOrder> { new AmazonOrder(), new EbayOrder() };

            foreach (var order in orders)
            {
               order.Process(); 
            }

            var enumerator = orders.GetEnumerator();

            while (enumerator.MoveNext())
            {
                if (enumerator.Current != null) enumerator.Current.Process();
            }
        }
    }


}