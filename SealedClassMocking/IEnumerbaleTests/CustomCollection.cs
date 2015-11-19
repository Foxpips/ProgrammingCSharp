using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammingTests.IEnumerbaleTests
{
    internal class CustomCollection<TType> : IEnumerable<TType> where TType : class, IComparable<TType>
    {
        protected internal TType[] ItemCollection { get; set; }

        public CustomCollection(TType[] itemCollection)
        {
            ItemCollection = itemCollection;
        }

        //Indexer
        public TType this[int index]
        {
            get { return ItemCollection.ElementAt(index); }
        }

        //Allows foreach on class
        public IEnumerator<TType> GetEnumerator()
        {
            return ((IEnumerable<TType>) ItemCollection).GetEnumerator();
        }

        public IEnumerator<TType> GetEnumeratorManually()
        {
            for (var i = 0; i < ItemCollection.Length; i++)
            {
                yield return ItemCollection[i];
            }
        }

        public void SortManual()
        {
            Array.Sort(ItemCollection);
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public void SortArray()
        {
            Array.Sort(ItemCollection);
        }

        public void SortIEnumerable()
        {
//            IEnumerable<TType> collection2 = ItemCollection;
//            var array = collection2.ToArray();
//            Array.Sort(array);

//            ItemCollection = array;
//            Console.WriteLine();


            List<Person> collection = ItemCollection.ToList() as List<Person>;
            new PersonSorter().SortCollection(ref collection);
        }
    }

    public class PersonSorter
    {
        public void SortCollection(ref List<Person> collection)
        {
            var collection2 = collection;
            var array = collection2.ToArray();
            Array.Sort(array);

            collection = array.ToList();
            Console.WriteLine();
        }
    }
}