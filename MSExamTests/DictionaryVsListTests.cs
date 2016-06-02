using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using ProgrammingTests.StringConcatenationProfiling;

namespace MSExamTests
{
    public class DictionaryVsListTests
    {
        [Test]
        public void InsertionTests()
        {
            var dictionary = new Dictionary<int, int>();
            var list = new List<int>();

            Timer.Time(() =>
            {
                for (var i = 0; i < 1000000; i++)
                {
                    dictionary.Add(i, i);
                }
                dictionary.Clear();
            }, "Dictionary Addition", 1);


            Timer.Time(() =>
            {
                for (var i = 0; i < 1000000; i++)
                {
                    list.Add(i);
                }
                list.Clear();
            }, "List Addition", 1);
        }

//        [Test]
//        public void SearchTests()
//        {
//            var dictionary = new Dictionary<int, int>();
//            var list = new List<int>();
//            KeyValuePair<int, int> x = new KeyValuePair<int, int>();
//            var p = 0;
//
//            for (var i = 0; i < 10000000; i++)
//            {
//                dictionary.Add(i, i);
//                list.Add(i);
//            }
//
//            // 1. Get random number.
//            int n = new Random().Next(10000);
//
//            // 2. Get random string.
//            Path.GetRandomFileName();
//            string k = l[n];
//            
//            if (d.ContainsKey(k))
//            {
//                hit = true;
//            } 
//        }
    }
}