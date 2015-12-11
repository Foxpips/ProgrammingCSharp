using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ProgrammingTests.DictionaryTests
{
    public class Actionary
    {
        [Test]
        public void CheckDictionary()
        {
            var dictionary = new Dictionary<string, Action>
            {
                {"a", () => Console.WriteLine("a")},
                {"b", () => Console.WriteLine("b")},
                {"c", () => Console.WriteLine("c")},
                {"d", () => Console.WriteLine("d")},
                {"e", () => Console.WriteLine("e")},
                {"f", () => Console.WriteLine("f")}
            };

            dictionary["a"].Invoke();
        }
    }
}