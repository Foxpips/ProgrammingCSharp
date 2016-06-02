using System;
using Autofac;
using Microsoft.Practices.Unity;
using StructureMap;

namespace IoCLibs
{
    public class IocRunner
    {
        public static void AutoFac()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Register(item => new TestClass { Name = "Simon" }).As<ITestInterface>();

            var container = containerBuilder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                var testInterface = scope.Resolve<ITestInterface>();
                //                Console.WriteLine(testInterface.Name);
            }
        }

        public static void StructureMap()
        {
            var container = new Container();
            //            container.Configure(cfg => cfg.For<ITestInterface>().Use<TestClass>());
            container.Configure(cfg => cfg.For<ITestInterface>().Use(item => new TestClass { Name = "Simon" }));
            using (container)
            {
                var testInterface = container.GetInstance<ITestInterface>();
                //                Console.WriteLine(testInterface.Name);     
            }
        }


        public static void Unity()
        {
            var container = new UnityContainer();
//            container.RegisterType<ITestInterface>(new InjectionConstructor("Name", new InjectionParameter<string>("Name")));

            container.RegisterType<ITestInterface, TestClass>(new InjectionConstructor("Simon"));
            using (container)
            {
                var testInterface = container.Resolve<ITestInterface>();
//                Console.WriteLine(testInterface.Name);
            }
        }
    }

    public class TestClass : ITestInterface
    {
        public string Name { get; set; }

        public TestClass()
        {
            
        }

        public TestClass(string Name)
        {
            this.Name = Name;
        }
    }

    public interface ITestInterface
    {
        string Name { get; set; }
    }
}