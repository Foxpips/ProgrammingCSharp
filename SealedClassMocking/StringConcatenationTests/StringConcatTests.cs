using System;
using System.Diagnostics;
using System.Threading;
using NUnit.Framework;

namespace ProgrammingTests.StringConcatenationTests
{
    public class StringConcatTests
    {
        [Test]
        public void String_Concat_Multiple()
        {
            Thread.Sleep(TimeSpan.FromSeconds(10));
            var concat = string.Concat("Hello ", "Simon ", "How ", "are ", "you?");

            Console.WriteLine(Process.GetCurrentProcess().WorkingSet64);
        }

        [Test]
        public void String_Format_Multiple()
        {
            Thread.Sleep(TimeSpan.FromSeconds(10));
            var concat = string.Format("{0}{1}{2}{3}{4}", "Hello ", "Simon ", "How ", "are ", "you?");
            Console.WriteLine(Process.GetCurrentProcess().WorkingSet64);
        }

//        [Test]
//        public void CompilerConverted_Example_Result()
//        {
//            Timer.Time(() =>
//            {
//                var toDateString = string.Concat(new object[]
//                {
//                    "10",
//                    "/",
//                    "10",
//                    "/",
//                    "2015"
//                });
//            }, "Concat");
//
//            Timer.Time(() => { var toDateString = string.Concat("Hello ", "Simon ", "How ", "are ", "you?"); }, "Concat");
//
//            Timer.Time(() => { var toDateString = string.Format("{0}{1}{2}{3}{4}", "Hello ", "Simon ", "How ", "are ", "you?"); }, "Format");
//        }
    }
}