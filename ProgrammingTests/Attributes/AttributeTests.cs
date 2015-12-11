using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace ProgrammingTests.Attributes
{
    public static class AttributeExtensions
    {
        public static T GetDomainAttributes<T>(this Type type) where T : DomainEntityAttribute
        {
            var attributeCollection = TypeDescriptor.GetAttributes(type);
            var enumerable = attributeCollection.Cast<T>().Single();

            return enumerable;
        }

        public static void SetDomainAttributes()
        {
            var exportedTypes = Assembly.GetExecutingAssembly().ExportedTypes;
            var entities = exportedTypes.Where(x => typeof (IDomainEntity).IsAssignableFrom(x) && x.IsClass);

            foreach (var entity in entities)
            {
                TypeDescriptor.AddAttributes(entity, new DomainEntityAttribute {TableName = entity.Name});
            }
        }
    }

    public class AttributeTests
    {
        [SetUp]
        public void SetUp()
        {
            AttributeExtensions.SetDomainAttributes();
        }

        [Test]
        public void TestAddingAttribute_DomainEntity_Dynamically()
        {
            var exportedTypes = Assembly.GetExecutingAssembly().ExportedTypes;
            var entities = exportedTypes.Where(x => typeof (IDomainEntity).IsAssignableFrom(x) && x.IsClass);

            foreach (Type entity in entities)
            {
                var domainEntityAttribute = entity.GetDomainAttributes<DomainEntityAttribute>();
                Console.WriteLine(domainEntityAttribute.TableName);
            }
        }


        [Test]
        public void TestAttribute_Scenario_Result()
        {
            var element = typeof (ConditionalClass);
            var type = typeof (ConditionalAttribute);
            var attribute = (ConditionalAttribute) Attribute.GetCustomAttributes(element, type).First();
            Console.WriteLine(attribute.ConditionString);


            var conditionalAttribute = new ConditionalClass();
            conditionalAttribute.PrintWordsCondition();
        }

        [Test]
        public void GetAttributes_Added_Dynamically()
        {
            var type = typeof (PersonOrderLine);

            TypeDescriptor.AddAttributes(type, new DomainEntityAttribute());

            IEnumerable<Attribute> customAttributes = type.GetCustomAttributes();

            var attributeCollection = TypeDescriptor.GetAttributes(type);

            foreach (var customAttribute in customAttributes)
            {
                Console.WriteLine(((DomainEntityAttribute) customAttribute).TableName);
            }
        }

        [Test]
        public void UpdateAttribute_PropertyAt_Runtime()
        {
            InitialiseDomainAttributes();
            var customAttributes = typeof (PersonOrderLine).GetCustomAttributes();
            var enumerator = customAttributes.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var domainEntityAttribute = enumerator.Current as DomainEntityAttribute;
                if (domainEntityAttribute != null) Console.WriteLine(domainEntityAttribute.TableName);
            }
        }

        private static void InitialiseDomainAttributes()
        {
            var exportedTypes = Assembly.GetExecutingAssembly().ExportedTypes;
            var entities = exportedTypes.Where(x => typeof (IDomainEntity).IsAssignableFrom(x) && x.IsClass);

            foreach (var entity in entities)
            {
                DomainEntityAttribute customAttribute = entity.GetCustomAttribute<DomainEntityAttribute>();
                customAttribute.TableName = entity.Name;
            }
        }
    }

    [DomainEntity]
    public class PersonOrderLine : IDomainEntity
    {
    }

    public interface IDomainEntity
    {
    }

    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class)]
    public class DomainEntityAttribute : Attribute
    {
        public string TableName { get; set; }
    }

    [Conditional("DEBUG")]
    public class ConditionalClass : Attribute
    {
        [Conditional("DEBUG")]
        public void PrintWordsCondition()
        {
            Console.WriteLine("Hello World");
        }
    }
}