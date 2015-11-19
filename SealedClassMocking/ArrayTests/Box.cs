using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace ProgrammingTests.ArrayTests
{
    public class Box : IComparable<Box>
    {
        public int Number { get; set; }

        public int CompareTo(Box other)
        {
            return Number.CompareTo(other.Number);
        }
    }

    public class Warehouse
    {
        public Box[] Boxes { get; set; }


        public void SortBoxes()
        {
            var boxSorter = new BoxSorter();
            var collection = Boxes.ToList();

            boxSorter.SortAsList(collection);
            Boxes = collection.ToArray();
        }
    }

    public class BoxSorter
    {
        public void SortAsArray(Box[] boxes)
        {
            Array.Sort(boxes);
        }

        public void SortAsList(List<Box> boxes)
        {
            boxes.Add(new Box {Number = 1000});
            var boxesToSort = boxes;
            var array = boxesToSort.ToArray();
            Array.Sort(array);

            boxes = array.ToList();
            Console.WriteLine();
        }
    }

    public class BoxTester
    {
        [Test]
        public void Test_Scenario_Result()
        {
            var warehouse = new Warehouse()
            {
                Boxes = new[] {new Box {Number = 3}, new Box {Number = 2}, new Box {Number = 77}}
            };

            warehouse.SortBoxes();

            foreach (var box in warehouse.Boxes)
            {
                Console.WriteLine(box.Number);
            }
        }
    }
}