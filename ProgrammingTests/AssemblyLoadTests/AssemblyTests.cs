using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace ProgrammingTests.AssemblyLoadTests
{
    public class AssemblyTests
    {

        protected string Hello {
            get { return "Hello there"; }
        }

        [Test]
        public void Test_Load_Assembly()
        {
            Assembly assembly1 = Assembly.GetExecutingAssembly();
            Assembly assembly2 = Assembly.Load(assembly1.FullName);
            Assembly assembly3 = Assembly.GetAssembly(GetType());

            Type firstOrDefault = assembly1.GetExportedTypes().FirstOrDefault();

            if (firstOrDefault != null)
            {
                var instance = Activator.CreateInstance(firstOrDefault) as AssemblyTests;
                if (instance != null) Console.WriteLine(instance.Hello);
            }


            Console.WriteLine(assembly1);
            Console.WriteLine(assembly2);
            Console.WriteLine(assembly3);
        }
    }
}