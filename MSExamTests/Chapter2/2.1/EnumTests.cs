using System;
using NUnit.Framework;

namespace MSExamTests.Chapter2._2._1
{
    public class EnumTests
    {
        public enum Gender
        {
            Male =0,
            Female =1
        }

        // The flags attribute should be used whenever the enumerable represents a collection of flags, rather than a single value. 
        // Such collections are usually manipulated using bitwise operators
        [Flags]
        public enum MyColours
        {
            Yellow = 1, //0001
            Green = 2,  //0010
            Red = 4,    //0100
            Blue = 8    //1000
        }

        [Flags]
        public enum Days
        {
            None = 0x0, //Hex values
            Sunday = 0x1, //1
            Monday = 0x2, //2
            Tuesday = 0x4, //4
            Wednesday = 0x8, //8
            Thursday = 0x10, //16
            Friday = 0x20, //32
            Saturday = 0x40 //64
        }

        [Flags]
        public enum Count
        {
            None = 0, //shifting the bits left same as binary above
            First = 1 << 0, //1
            Second = 1 << 1, //2
            Third = 1 << 2, //4
            Fourth = 1 << 3, //8
            Fifth = 1 << 4 //16
        }

        [Test]
        public void EnumTests_Scenario_Result()
        {
            Console.WriteLine(Gender.Female);
            
            //Example of explicit cast
            Console.WriteLine((int)Gender.Female);
        }

        [Test]
        public void UsingFlags_Attribute_Result()
        {   //embedded directly into IL Code
            const MyColours allowedColors = MyColours.Yellow | MyColours.Green;

            var myColour = MyColours.Yellow;
            var myOtherColour = MyColours.Red;

            if ((allowedColors & MyColours.Yellow) == myColour)
            {
                Console.WriteLine(@"Yellow is allowed!");
            }

            if (allowedColors.HasFlag(MyColours.Green))
            {
                Console.WriteLine(@"Green is allowed!");
            }

            Console.WriteLine((allowedColors.HasFlag(myOtherColour) ? @"Yellow is allowed!" : @"Red is not allowed"));
        }
    }
}