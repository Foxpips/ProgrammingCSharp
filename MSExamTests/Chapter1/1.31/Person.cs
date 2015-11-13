using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace MSExamTests.Chapter1._1._31
{
    public class Person
    {
        public string Name { get; set; }
    }

    public class PersonTester
    {
        [Test]
        public void Method_Scenario_Result()
        {
            var people = new List<Person>{new Person{Name = "Joey"},new Person{Name = "Ted"}};

            List<Person>.Enumerator enumerator = people.GetEnumerator();

            try
            {
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current != null) Console.WriteLine(enumerator.Current.Name);
                }
            }
            finally
            {
                var disposable = enumerator as IDisposable;
                disposable.Dispose();
            }
        }
    }
}