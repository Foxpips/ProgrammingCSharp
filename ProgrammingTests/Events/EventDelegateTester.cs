using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using ProgrammingTests.DelegateTests;

namespace ProgrammingTests.Events
{
    public class EventDelegateTester
    {
        private readonly List<User> _users = new List<User>();

        public void AddUser(string name = "name")
        {
            var user = new User(name);
            _users.Add(user);
            user.Renamed2 +=
                delegate(object sender, RenamedEventArgs e)
                {
                    Console.WriteLine("{0} was renamed to {1}!", e.OldName, e.Name);
                };

            user.Renamed2 += (sender, e) => { Console.WriteLine("ZOMG its " + e.Name); };
        }

        [Test]
        public void Method_Scenario_Result()
        {
            var eventDelegateTester = new EventDelegateTester();
            eventDelegateTester.AddUser();
            
            var firstOrDefault = eventDelegateTester._users.FirstOrDefault();

            

            if (firstOrDefault != null)
            {
                var renamedEventArgs = new RenamedEventArgs(WatcherChangeTypes.All, String.Empty, "Joe", "Simon");
//                firstOrDefault.Renamed2(this,renamedEventArgs);
                firstOrDefault.OnRenamed2(renamedEventArgs);
            }
        }
    }
}