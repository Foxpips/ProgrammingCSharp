using System;
using System.Collections.Generic;

namespace SealedClassMocking.Extensions
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
    }
}