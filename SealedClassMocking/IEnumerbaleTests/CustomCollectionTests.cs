using System;
using AutoMapper;
using NUnit.Framework;
using ProgrammingTests.Extensions;

namespace ProgrammingTests.IEnumerbaleTests
{
    public class CustomCollectionTests
    {
        [Test]
        public void CustomCollection_Iterate_List()
        {
            var customCollection =
                new CustomCollection<Person>(new[]
                {new Person("Ted", "A"), new Person("Andrew", "B"), new Person("Bob", "C")});

            var enumerator = customCollection.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.FirstName);
            }

            Console.WriteLine("\nSorted via Extension:");

//            customCollection.SortArray();
            customCollection.SortIEnumerable();
//            customCollection.ItemCollection.SortSelf();
            EnumerableExtensions.Each(customCollection, Console.WriteLine);

//            Console.WriteLine("\nSorted Directly:");
//            customCollection.SortManual();
//            customCollection.Each(Console.WriteLine);
        }
    }
}