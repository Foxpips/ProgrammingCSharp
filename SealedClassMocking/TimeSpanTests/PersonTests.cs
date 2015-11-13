using System;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;

namespace SealedClassMocking
{
    public class PersonTests
    {
        [Test]
        public void GetPerson_Mocked_GetsName()
        {
            var personMock = MockRepository.GenerateMock<Person>();

          personMock.Stub(person => person.GetCredentials()).Return("Simon");

            var credentials = personMock.GetCredentials();

            Console.WriteLine(credentials);
        }
    }
}