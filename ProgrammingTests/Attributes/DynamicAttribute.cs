using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using NUnit.Framework;
using ProgrammingTests.Attributes;

namespace ProgrammingTests.Attributes
{
    public class DynamicAttribute : Attribute
    {
        public string Value { get; set; }


        public DynamicAttribute(string value)
        {
            Value = value;
        }
    }

    public class SomeClass
    {
        public string Value = "Test";
    }
}

public class AttributeAdderTester
{
    [Test]
    public void CanAddAttribute()
    {
        var type = typeof (SomeClass);

        

        AssemblyName aName = new AssemblyName("SomeNamespace");
        AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly(aName, AssemblyBuilderAccess.Run);
        ModuleBuilder mb = ab.DefineDynamicModule(aName.Name);
        TypeBuilder tb = mb.DefineType(type.Name, TypeAttributes.Public, type);
        TypeDescriptor.AddAttributes(type);

        Type[] attrCtorParams = {typeof (string)};
        ConstructorInfo attrCtorInfo = typeof (DynamicAttribute).GetConstructor(attrCtorParams);

        if (attrCtorInfo != null)
        {
            CustomAttributeBuilder attrBuilder = new CustomAttributeBuilder(attrCtorInfo, new object[] {"Some Value"});
            tb.SetCustomAttribute(attrBuilder);
        }

        Type newType = tb.CreateType();
        SomeClass instance = (SomeClass) Activator.CreateInstance(newType);
        DynamicAttribute attr = (DynamicAttribute) instance.GetType().GetCustomAttributes(typeof (DynamicAttribute), false).SingleOrDefault();

        Assert.AreEqual("Test", instance.Value);
        Assert.IsNotNull(attr);
        Assert.AreEqual(attr.Value, "Some Value");
    }
}