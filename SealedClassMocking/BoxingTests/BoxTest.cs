using System;
using NUnit.Framework;

namespace SealedClassMocking.BoxingTests
{
    public class BoxTest
    {
        [Test]
        public void Int_Box_FloatFromObject()
        {
            float price = 10.2f;

            object amountRef = price;

            Console.WriteLine(amountRef);
            var value = (int) (float) amountRef;
            Console.WriteLine(value);
        }
    }
}