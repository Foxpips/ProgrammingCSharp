using System;
using NUnit.Framework;

namespace MSExamTests.Chapter1.AccessModifiers
{
   
    public class AccessModifierClass
    {
        public string Type { get; set; }
    }


    public class TestAccess
    {
        [Test]
        public void Method_Scenario_Result()
        {
            var baseClass = new AccessModifierClass(){Type = "g"};
            Console.WriteLine(baseClass.Type);
            
        }
    }
}