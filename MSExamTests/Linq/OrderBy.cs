using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace MSExamTests.Linq
{
    public class OrderBy
    {
        private readonly decimal[] _loanAmounts = {300m, 10m, 12m, 24m};

        public IOrderedEnumerable<decimal> LinqOrder()
        {
            var orderedEnumerable = from amount in _loanAmounts
                where amount%2 == 0
                orderby amount ascending
                select amount;
            return orderedEnumerable;
        }

        [Test]
        public void Order_LoanDecimals_Ascending()
        {
            //OrderBy is order by Ascending.... nice thanks microsoft for making that clear
            IEnumerable<decimal> orderByDescending =_loanAmounts.Where(amount => amount%2 == 0).OrderByDescending(amount => amount);
            IEnumerable<decimal> orderByAscending = _loanAmounts.Where(item => item%2 == 0).OrderBy(amount => amount);

            Console.WriteLine("Descending: ");
            foreach (var @decimal in orderByDescending)
            {
                Console.WriteLine(@decimal);
            }

            Console.WriteLine("\nAscending: ");
            foreach (var @decimal in orderByAscending)
            {
                Console.WriteLine(@decimal);
            }
        }
    }
}