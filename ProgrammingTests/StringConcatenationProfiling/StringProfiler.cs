using System.Text;
using NUnit.Framework;

namespace ProgrammingTests.StringConcatenationProfiling
{
    public class StringProfiler
    {
        private const string FirstName = "hello";
        private const string LastName = "There";

        [Test]
        public void Method_Scenario_Result()
        {
            Timer.Time(() => string.Concat(FirstName, LastName), "concat");
            Timer.Time(() => FirstName + LastName, "+");
            Timer.Time(() =>
            {
                var stringBuilder = new StringBuilder(FirstName);
                stringBuilder.Append(LastName);
                return stringBuilder.ToString();
            }, "stringbuilder");
            Timer.Time(() => string.Format("{0}_", FirstName), "format");
        }
    }
}