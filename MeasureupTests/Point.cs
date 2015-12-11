using System;
using NUnit.Framework;

namespace MeasureupTests
{
    public class Point
    {
    }


    public class TestCastStructs
    {
        [Test]
        public void Method_Scenario_Result()
        {
            var point = new Point();

            var k = new object();

            Assert.Throws<InvalidCastException>(() => { var point1 = (Point) k; });
        }
    }
}