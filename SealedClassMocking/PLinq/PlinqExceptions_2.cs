using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ProgrammingTests.PLinq
{
    public class PlinqExceptions2
    {
        // Paste into PLINQDataSample class.
        [Test]
        public void PLINQExceptions_2()
        {
            var customers = GetCustomersAsStrings().ToArray();

            // Create a delegate with a lambda expression.
            // Assume that in this app, we expect malformed data
            // occasionally and by design we just report it and continue.
            Func<string[], string, bool> getDetailsSafe = (f, c) =>
            {
                try
                {
                    string s = f[3];
                    return true;
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine("Malformed cust: {0}", f);
                    return false;
                }
            };

            Func<string[], string, bool> getDetailsUnSafe = (f, c) =>
            {
                string s = f[3];
                return true;
            };

            // Using the raw string array here
            var parallelQuery = from cust in customers.AsParallel()
                let fields = cust.Split(',')
                where getDetailsUnSafe(fields, "C")
                //use a named delegate with a try-catch
                select new {city = fields[3], name = fields[2]};
            try
            {
                // We use ForAll although it doesn't really improve performance
                // since all output must be serialized through the Console.
                parallelQuery.ForAll(e => Console.WriteLine(e.name + " is from " + e.city));
            }

                // IndexOutOfRangeException will not bubble up      
                // because we handle it where it is thrown.
            catch (AggregateException e)
            {
                foreach (var ex in e.InnerExceptions)
                    Console.WriteLine(ex.Message + "\n exceptions count:" + e.InnerExceptions.Count);
            }
        }

        private static IEnumerable<string> GetCustomersAsStrings()
        {
            var customersAsStrings = new List<string>
            {
                "Customer,1,John,Carlow",
                "###",
                "Customer,3,Mike,Limerick",
                "###",
                "Customer,5,Scott,Dublin"
            };


            return customersAsStrings;
        }
    }
}