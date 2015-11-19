using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ProgrammingTests.DelegateTests
{
    public class DelegateTests
    {
        public delegate void AddUserCallback(string s, int i);

        public class UserTracker
        {
            private readonly List<string> _users = new List<string>();

            public void AddUser(string name, Action<string, int> callback)
            {
                _users.Add(name);
                callback(name, _users.Count);
            }
        }

        public class Runner
        {
            private readonly UserTracker _tracker = new UserTracker();
            private readonly Action<string, int> _callback = (s, i) => Console.WriteLine("Name {0} Count {1}", s, i);

            public void Add(string name)
            {
                _tracker.AddUser(name, _callback);
            }
        }

        public class TestRunner
        {
            [Test]
            public void Method_Scenario_Result()
            {
                var runner = new Runner();
                runner.Add("Simon");
                runner.Add("Bary");
                runner.Add("John");
                runner.Add("Scot");
            }
        }
    }
}