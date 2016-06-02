using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public static ICollection<T> SortSelf<T>(this ICollection<T> collection) where T : IComparable<T>
        {
            var array = collection.ToArray();
            Array.Sort(array);

            collection.Clear();
            collection.AddAll(array);

            return collection;
        }

        public static byte[] ToByteArray(this string content)
        {
            return Encoding.ASCII.GetBytes(content);
        }
    }
}