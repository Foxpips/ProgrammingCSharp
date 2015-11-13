using System;
using NUnit.Framework;

namespace MSExamTests.Chapter2._2._2
{


    public class Employee
    {
        public Employee()
        {
            
        }

        public void GetName()
        {
        }

    }


    public class TestEmployee
    {
        [Test]
        public void Method_Scenario_Result()
        {
            var employee = new Employee();
        }
    }

    public struct PointBase
    {
        public int? X, Y;
        public const int Coolness = 1;

        public PointBase(int p1, int p2)
        {
            X = p1;
            Y = p2;
        }
    }


    public class MyPoint
    {
        public int mynum { get; set; }
    }

    public class PointTester
    {

        [Test]
        public void Method_Scenario_Result()
        {
            int a = 10;
            int b = a;

            a = 20;

            Console.WriteLine(b);


        }

        [Test]
        public void ref_Scenario_Result()
        {
            var myPoint = new MyPoint {mynum = 10};
            var myPoint2 = myPoint;

            myPoint.mynum = 20;

            Console.WriteLine(myPoint2.mynum);
        }
    }




}