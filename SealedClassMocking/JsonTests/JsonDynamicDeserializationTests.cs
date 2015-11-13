using System;
using Newtonsoft.Json;
using NUnit.Framework;

namespace SealedClassMocking.JsonTests
{
    public class JsonDynamicDeserializationTests
    {
        [Test]
        public void Test_DeserializeJson_ToDynamic()
        {
            var request = JsonConvert.SerializeObject(new HolidayRequest {StartDate = DateTime.Now});

            dynamic holiday = JsonConvert.DeserializeObject(request);

            Console.WriteLine(holiday.StartDate);
        }
    }

    public class HolidayRequest
    {
        public DateTime StartDate { get; set; }
    }
}