using System;
using System.Data;
using System.Linq.Expressions;
using NUnit.Framework;

namespace SealedClassMocking.DateComparer
{
    public static class Extensions
    {
        public static void Method(this string mystring)
        {
            Console.WriteLine("");
        }

        private static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static T ToEnum<T>(this string value)
        {
            return (T) Enum.Parse(typeof (T), value, true);
        }

        public static int GetDaysBetween(this DateTime starDate, DateTime endDate)
        {
            var totalDays = 0;
            for (int i = starDate.DayOfYear; i <= endDate.DayOfYear; i++)
            {
                totalDays++;
            }
            return totalDays;
        }
    }

    public static class Extensions2
    {
        public static T Create<T>(this T @this)
            where T : class, new()
        {
            return Utility<T>.Create();
        }
    }

    public static class Utility<T>
        where T : class, new()
    {
        static Utility()
        {
            Create = Expression.Lambda<Func<T>>(Expression.New(typeof (T).GetConstructor(Type.EmptyTypes))).Compile();
        }

        public static Func<T> Create { get; private set; }
    }

    public class DateComparisonTests
    {
        [Test]
        public void DateCompared_Scenario_Result()
        {
            var start = new DateTime(2016, 02, 28);
            //Adding day to account for hours offset
            var end = new DateTime(2016, 02, 28);
            Console.WriteLine(start.GetDaysBetween(end));
        }

        [Test]
        public void Method_Scenario_Result()
        {
            var start = new DateTime(2015, 10, 10);
            //Adding day to account for hours offset
            var end = new DateTime(2015, 10, 11).AddDays(1);

            Console.WriteLine(start.TimeOfDay - end.TimeOfDay);

            var timeSpan = (end - start);
            Console.WriteLine(timeSpan.ToString("g"));
        }

        [Test]
        public void test_Scenario_Result()
        {
            var ds1 = (null as DataSet).Create(); // as oppose to DataSet.Create()
            // or
            DataSet ds2 = null;
//            ds2 = Extensions2.Create((null as Console));
        }

        [Test]
        public void Pizza_Scenario_Result()
        {
            var @enum = "Pizza".ToEnum<Food>();
            Assert.That(@enum.Equals(Food.Pizza));
            Assert.Equals("hello", "hello");
        }

        public enum Food
        {
            Pizza,
            Spaghetti
        }
    }
}