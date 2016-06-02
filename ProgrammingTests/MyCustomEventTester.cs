using System;
using NUnit.Framework;

namespace ProgrammingTests
{
    public class MyCustomEventTester : Exception
    {
        public delegate string Combine(string s1, string s2);


        [Test]
        public void Method_Scenario_case(string s)
        {
            switch (s)
            {
                case "Hello":
                    goto case "Joey";
                 //Fall through
                case "Mickael":
                    Console.WriteLine("Hi there!");
                    break;
                case "Joey":
                    Console.WriteLine("Hi Joey");
                    break;
            }
        }

        [Test]
        public void Method_Scenario_Result()
        {


            try
            {
                Combine combine = delegate(string s1, string s2) { return s1 + s2; };
            }
            catch(Exception ex)
            {
                throw;
            }

            Combine combine2 = (s1, s2) => { return s1 + s2; };
        }
    }

    public class ErrorEventArgs : EventArgs
    {
        private readonly string error;

        public ErrorEventArgs(string error)
        {
            this.error = error;
        }

        public string Error
        {
            get { return error; }
        }
    }


    public class TestThisError
    {
        public delegate void ErrorEventHandler(ErrorEventArgs a);

        public delegate void ErrorEventHandlerTrue(object sender, ErrorEventArgs a);


        public event ErrorEventHandler MyError;

        protected virtual void OnMyError(ErrorEventArgs a)
        {
            var handler = MyError;
            if (handler != null) handler(a);
        }
    }
}