using System.Collections.Generic;

namespace ProgrammingTests.IEnumerbaleTests
{
    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.CompareTo(y);
        }
    }
}