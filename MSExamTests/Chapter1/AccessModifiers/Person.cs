using System;
using NUnit.Framework;

namespace MSExamTests.Chapter1.AccessModifiers
{
    public class PersonLocal : IDisposable
    {
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }

                _firstName = value;
            }
        }

        public void Dispose()
        {
            Console.WriteLine(@"Disposing");
        }
    }

    public class PersonHelper
    {
        public PersonLocal PersonLocal { get; set; }

        public PersonHelper()
        {
            PersonLocal = new PersonLocal();
        }
    }

    public class TestPerson
    {
        [Test]
        public void Method_Scenario_Result()
        {
//            using (var personLocal = new PersonLocal())
//            {
//                personLocal.FirstName = "Jason";
//            }


            var personHelper = new PersonHelper();
            try
            {
                personHelper.PersonLocal.FirstName = "";
            }
            catch (ArgumentException ex)
            {
                throw new StackOverflowException("Overflowing!");
            }
            finally
            {
                personHelper.PersonLocal.Dispose();
            }
        }
    }
}