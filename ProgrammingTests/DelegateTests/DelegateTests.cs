using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using ProgrammingTests.Events;

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

            public void AddUser2(string name = "Hello")
            {
                var user = new User(name);
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

            [Test]
            public void Method_Scenario_UserTRacker()
            {
                var userTracker = new UserTracker();
                userTracker.AddUser2("Simon");
            }
        }
    }

    public class User
    {
        private string _name;

        public delegate void Renamed(object sender, RenamedEventArgs e);

        //events can only appear on the left hand side of += or -= and cannot be invoke by another class
//        public EventHandler<RenamedEventArgs> Renamed2;
        public event EventHandler<RenamedEventArgs> Renamed2;

        public delegate void Delmethod(int x, int y);

        public User(string name)
        {
            SetDelegate();
            _name = name;
        }

        public void SetDelegate()
        {
            Delmethod del = (x, y) => Console.WriteLine(1);
        }

        public virtual void OnRenamed2(RenamedEventArgs e)
        {
            var handler = Renamed2;
            if (handler != null) handler.Raise(this, e);
        }
    }
}