using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace MeasureupTests
{
    public class QueryTests
    {
        [Test]
        public void Method_Scenario_Result()
        {
            const string honda = "Honda";
            var enumerable = Vehicle.GetVehicles().Where(v => v.Make == honda).Select(v => v.Make);
            var car = from v in Vehicle.GetVehicles().Where(v => v.Make.Equals(honda)) select new {v.Make};
            var car2 = Vehicle.GetVehicles().Where(v => v.Make.Equals(honda)).Select(x => new {x.Make});
            var cars = Vehicle.GetVehicles().Where(v => v.Make.Equals(honda)).SelectMany(x => new List<Vehicle>() {new Vehicle {Make = x.Make}}).ToList();


            foreach (var carType in car)
            {
                Console.WriteLine(carType.Make);
            }

            foreach (var carType in car2)
            {
                Console.WriteLine(carType.Make);
            }

            foreach (var vehicle in cars)
            {
                Console.WriteLine(vehicle.Make);
            }

            var enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
    }

    public class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public static List<Vehicle> GetVehicles()
        {
            return new List<Vehicle>
            {
                new Vehicle {Make = "Honda", Model = "Civic", Year = 2010},
                new Vehicle {Make = "Honda", Model = "Terios", Year = 2011},
                new Vehicle {Make = "Nissan", Model = "Micra", Year = 2012}
            };
        }
    }
}