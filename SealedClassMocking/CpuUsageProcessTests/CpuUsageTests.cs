using System;
using System.Diagnostics;
using System.Text;
using NUnit.Framework;

namespace ProgrammingTests.CpuUsageProcessTests
{
    public class CpuUsageTests
    {
        private readonly PerformanceCounter _theCpuCounter = new PerformanceCounter("Processor", "% Processor Time",
            "_Total");

        private readonly PerformanceCounter _theMemCounter = new PerformanceCounter("Memory", "Available MBytes");


        [Test]
        public void MonitorCpuUsage_Format_Vs_Concat()
        {
            var theCpuCounter = new PerformanceCounter("Process", "% Processor Time",
                Process.GetCurrentProcess().ProcessName);
            var theMemCounter = new PerformanceCounter("Process", "Working Set", Process.GetCurrentProcess().ProcessName);

            StringBuilder s = new StringBuilder();

            s.Append("as");
            Console.WriteLine(s.ToString());
            Console.WriteLine(theCpuCounter.NextValue());
            Console.WriteLine(theMemCounter.NextValue());
        }
    }
}