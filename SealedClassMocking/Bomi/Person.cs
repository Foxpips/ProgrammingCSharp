using System;

namespace SealedClassMocking.Bomi
{
    public interface ICustomer
    {
        bool PurchaseItem();
    }

    public interface IPerson : ICustomer
    {
    }

    public class Person : IPerson
    {
        bool ICustomer.PurchaseItem()
        {
            Console.WriteLine("Purchased stuff");
            return true;
        }
    }
}