using System;
using NUnit.Framework;

namespace SealedClassMocking.Tuple
{
    public class DbObject
    {
        public String Item1 { get; set; } 
        public String Item2 { get; set; } 
    }

    public class TestTuples
    {
        [Test]
        public void Method_Scenario_Result()
        {
            var dbObject = new DbObject();
            var dbObject2 = new DbObject();
        }
    }
}