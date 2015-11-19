using System;
using NUnit.Framework;

namespace ProgrammingTests.IntTests
{
    public class IntegerTester
    {
        [Test]
        public void Method_Scenario_Result()
        {
            object number = "001111111";
            object numberInvalid = "001111111adsa";
            string numbernull = null;
            object  numberEmpty = "";





            int result;
            var tryParse = int.TryParse(number.ToString(), out result);
            var tryParse2 = int.TryParse(numberInvalid.ToString(), out result);

//            var invalid = (object)numbernull;
//            var tryParse3 = int.TryParse(invalid.ToString(), out result);
            var tryParse4 = int.TryParse(null, out result);

//            Console.WriteLine(tryParse);
//            Console.WriteLine(tryParse2);
//            Console.WriteLine(tryParse3);
            Console.WriteLine(tryParse4);


        }
    }
}