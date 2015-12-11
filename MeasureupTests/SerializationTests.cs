using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using NUnit.Framework;

namespace MeasureupTests
{
    public partial class Order
    {
        partial void OnListPriceChanging();
    }

    [DataContract]
    public partial class Order
    {
        [DataMember]
        public int Number { get; set; }

        [DataMember]
        public double Amount { get; set; }

        public virtual void GetStuff()
        {
            Console.WriteLine();
        }

        partial void OnListPriceChanging()
        {
            Console.WriteLine(Amount);
        }
    }

    public class SerializationTests
    {
        [Test]
        public void SerializeThis()
        {
            var order = new Order {Amount = 19f, Number = 10};
//            order.OnListPriceChanging();

            var dataContractJsonSerializer = new DataContractJsonSerializer(order.GetType());

            var memoryStream = new MemoryStream();
            dataContractJsonSerializer.WriteObject(memoryStream, order);


            memoryStream.Position = 0;
            using (var streamReader = new StreamReader(memoryStream))
            {
                var readToEnd = streamReader.ReadToEnd();
                Console.WriteLine(readToEnd);
            }
        }
    }
}