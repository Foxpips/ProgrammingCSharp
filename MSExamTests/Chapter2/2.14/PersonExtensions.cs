using System;

namespace MSExamTests.Chapter2._2._14
{
    public static class PersonExtensions
    {
        public static void ThrowStick<T>(this IPerson<T> person) where T : BasePet
        {
            Console.WriteLine(@"{0} throws a stick and {1} runs after it yipping!!", person.Name, person.Pet.Name);
        }
    }
}