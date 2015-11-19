using System;
using System.Collections;
using System.IO;
using NUnit.Framework;

namespace ProgrammingTests
{
    public class MsTest
    {
        [Flags]
        [Serializable]
        public enum DaysOfWeek : short
        {
            None,
            Monday,
            Tuesday,
            Wednesday,
            Thursday
        }


        [Test]
        public void Method_Scenario_Result()
        {
            DayOfWeek test;
            var daysOfWeek = Enum.TryParse("Monday, Tuesday, Wednesday, Thursday", true, out test);

            Console.WriteLine(daysOfWeek + " " + test.ToString());
            
        }


        [Test]
        public void StreamReader_Scenario_Result()
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes("Hello there");

            using (var streamReader = new StreamReader(new MemoryStream(bytes)))
            {
                Console.WriteLine(streamReader.ReadToEnd());
            }
        }

        [Test]
        public void Queue_vs_Stack()
        {
            var queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            queue.Dequeue();
            queue.Dequeue();

            Console.WriteLine(queue.Dequeue());

            var stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            stack.Pop();
            stack.Pop();

            Console.WriteLine(stack.Peek());
            
        }
    }
}