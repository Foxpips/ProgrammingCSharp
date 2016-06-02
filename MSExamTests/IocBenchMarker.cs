using IoCLibs;
using NUnit.Framework;
using ProgrammingTests.StringConcatenationProfiling;

namespace MSExamTests
{
    public class IocBenchMarker
    {
        [Test]
        public void Method_Scenario_Result()
        {
            Timer.Time(IocRunner.AutoFac, "AutoFac", 10000);
            Timer.Time(IocRunner.StructureMap, "StructureMap", 10000);
            Timer.Time(IocRunner.Unity, "Unity", 10000);
        }
    }
}