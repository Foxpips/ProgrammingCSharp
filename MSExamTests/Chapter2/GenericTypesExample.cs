using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace MSExamTests.Chapter2
{
    public class GenericTypesExample
    {
        [Test]
        public void Method_Scenario_Result()
        {
            var arrayList = new List<int>();
            var arrayList2= new ArrayList();

            int myint = 7;
            arrayList.Add(7);

            foreach (var item in arrayList)
            {
                int i = item;
            }
        }
    }
}