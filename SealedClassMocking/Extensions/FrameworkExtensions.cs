using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammingTests.Extensions
{
    public static class FrameworkExtensions
    {
        public static void Each<T>(this IEnumerable<T> enumerable, Action<T> work)
        {
            foreach (var item in enumerable)
            {
                work(item);
            }
        }

        public static void AddAll<T>(this ICollection<T> currentCollection, ICollection<T> collection)
        {
            foreach (var item in collection)
            {
                currentCollection.Add(item);
            }
        }

        public static void SortSelf<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            var array = collection.ToArray();
            Array.Sort(array);
        
            collection = array;
        }
    }
}