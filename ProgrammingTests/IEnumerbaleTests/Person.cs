using System;

namespace ProgrammingTests.IEnumerbaleTests
{
    public class Person : ICollectionItem, IComparable<Person>
    {
        protected internal string FirstName { get; set; }
        protected internal string SurName { get; set; }

        public Person(string firstName, string surName)
        {
            FirstName = firstName;
            SurName = surName;
        }

        public override string ToString()
        {
            return string.Concat(FirstName, " ", SurName);
        }

        public int CompareTo(Person other)
        {
            var compareTo = string.Compare(FirstName, other.FirstName, StringComparison.OrdinalIgnoreCase);
            return compareTo;
        }
    }
}