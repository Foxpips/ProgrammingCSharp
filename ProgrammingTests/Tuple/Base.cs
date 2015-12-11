using System;

namespace ProgrammingTests.Tuple
{
    public abstract class Base
    {
        public virtual void MethodWithImplementation()
        {
            Console.WriteLine();
        }

        public abstract void AbstractMethod();
    }


    public class Derived : Base
    {
        public override void AbstractMethod()
        {
            Console.WriteLine("Derived");
        }
    }


    public class VeryDerived : Derived
    {
        public override void AbstractMethod()
        {
            base.AbstractMethod();
        }
    }
}