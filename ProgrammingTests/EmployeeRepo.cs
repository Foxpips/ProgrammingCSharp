using System;
using System.IO;
using NUnit.Framework;

namespace ProgrammingTests
{
    public class TestRepo
    {
        [Test]
        public void Method_Scenario_Result()
        {
//            var createRepo = new CreateRepo<Phone>();

        }
    }

    public class CreateRepo<T> where T : Phone, new()
    {
        public void CreatePhone()
        {
            var foo = new T();
            var streamReader = new StreamReader("");
        }
    }

    public class Phone
    {
        private string _s;

        public Phone(string s)
        {
            _s = s;
        }
    }

    public abstract class EmployeeRepo
    {
        public abstract Employee GetEmployee1(int i);
        public abstract Employee GetEmployee1(string i);
        public abstract Employee GetEmployee1(int? i);

        public abstract Employee GetEmployee2(int i);
        public abstract Employee GetEmployee2(string i);
        public abstract Employee GetEmployee2(int i, string a);

        //        public abstract Employee GetEmployee3(int i);
        //        public abstract Employee GetEmployee3(string i);
        //        public abstract Employee GetEmployee3(Int32 i);

        //public abstract Employee GetEmployee(int i);
        //public abstract Employee GetEmployee(string i);
        //public abstract void GetEmployee(int i);
    }

    public class Employee
    {
    }
}