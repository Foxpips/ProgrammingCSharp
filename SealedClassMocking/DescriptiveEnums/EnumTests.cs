using System;
using NUnit.Framework;

namespace SealedClassMocking.DescriptiveEnums
{
    public class EnumTests
    {
        [Test]
        public void Method_Scenario_Result()
        {
            var myEnum = ScheduleEnum.Daily;

            myEnum.Description();
        }


        [Test]
        public void FActory_Property_EnumTest()
        {
            var factory = new Factory {NormalShift = ScheduleEnum.Weekly};
            Console.WriteLine(factory.NormalShift.Description());
        }

        [Test]
        public void Null_Scenario_Result()
        {
            object test = null;
            var type = test.GetType();

        }

        [Test]
        public void FActoryNull_Property_EnumTest()
        {

            var factory = new Factory();
            factory.NormalShift = null;
            Console.WriteLine(factory.NormalShift.Description());
        }


        public class Factory
        {
            public ScheduleEnum? NormalShift { get; set; }
        }
    }
}