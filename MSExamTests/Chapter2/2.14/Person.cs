using System;
using NUnit.Framework;

namespace MSExamTests.Chapter2._2._14
{

    #region Toy

    public interface IPet
    {
        void Play();
    }

    public abstract class BasePet : IPet
    {
        public string Owner { get; set; }
        public string Name { get; set; }

        public virtual void Play()
        {
            Console.WriteLine(@"{0} plays {1}", Name, Owner);
        }
    }

    public class Dog : BasePet
    {
        public override void Play()
        {
            Console.WriteLine(@"{0} plays with {1}!", Name, Owner);
        }
    }

    #endregion

    #region animal

    public interface IPerson<T> where T : BasePet
    {
        string Name { get; set; }
        T Pet { get; set; }
        void PlayWithPet();
    }

    public class Person<T> : IPerson<T> where T : BasePet, new()
    {
        public T Pet { get; set; }
        public string Name { get; set; }

        public Person(string name, string petName)
        {
            Name = name;
            Pet = new T { Name = petName, Owner = name };
        }

        public void PlayWithPet()
        {
            if (Pet == null)
            {
                Console.WriteLine(@"{0} does not have a pet :-(", Name);
                return;
            }

            Pet.Play();
        }
    }

    #endregion

    public class TestProperties
    {
        [Test]
        public void Test_Generic_Class()
        {
            var person = new Person<Dog>("Simon", "Jeff the Spaniel");
            person.PlayWithPet();

            Console.WriteLine();

            person.ThrowStick();
        }
    }
}