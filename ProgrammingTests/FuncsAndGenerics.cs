using System;
using NUnit.Framework;
using ProgrammingTests.Bomi;

namespace ProgrammingTests
{
    public class FuncsAndGenerics<TType> where TType : IPerson
    {
        public TType MyType { get; private set; }

        public TEmployeeType GetEmployee<TEmployeeType>() where TEmployeeType : IEmployee, new()
        {
            return new TEmployeeType();
        }


        [Test]
        public void TestGenerics()
        {
            var employee = GetEmployee<Analyst>();

            
        }


        public class Analyst : IEmployee
        {
        }

        public class Consultant : IEmployee
        {
        }

        public interface IEmployee
        {
        }

        [Test]
        public void Method_Scenario_Result()
        {
            Greet((person1, person2) =>
            {
                Console.WriteLine(person1.Name);
                Console.Write(person2.Name);
            });
        }

        public void Greet(Action<Person, Person> action)
        {
            var person = new Person {Name = "Po"};
            var person2 = new Person {Name = "Simon"};

            Console.WriteLine("Hello");
            action(person, person2);
        }


        public void OurMethod(Person x)
        {
            Console.WriteLine("Po");
        }

        public class Person
        {
            public string Name { get; set; }
        }
    }
}