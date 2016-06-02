using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using NUnit.Framework;

namespace MSExamTests
{
    [DataContract(Namespace = "www.test.com")]
    public class Employee
    {

        public void Do()
        {
            
        }

        [DataMember]
        public string Second { get; set; }

        [DataMember(Order = 10)]
        public string First { get; set; }
//
//        [DataMember(Order = 3)]
//        public string Third { get; set; }
//
//        [DataMember(Order = 4)]
//        public string Fourth{ get; set; }
//
//        [DataMember(Order = 5)]
//        public string Fifth{ get; set; }
//
//        [DataMember(Order = 6)]
//        public string Sixth{ get; set; }
    }

    // You must apply a DataContractAttribute or SerializableAttribute
    // to a class to have it serialized by the DataContractSerializer.
    [DataContract(Name = "Customer", Namespace = "http://www.MSExamTests.com")]
    internal class Person : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, IsRequired = true)]
        public string FirstName;
        [DataMember(IsRequired = true)]
        public string LastName;
        [DataMember(IsRequired = true)]
        public int Id;

        public ExtensionDataObject ExtensionData { get; set; }
    }

    public class Test
    {
        [Test]
        public void TestEmplopyee_Scenario_Result()
        {
            WriteObject("employee.xml");
            ReadObject("employee.xml");
            string[] readAllLines = File.ReadAllLines(@"C:\Users\SimonMarkey\Documents\GitHub\ProgrammingCSharp\MSExamTests\bin\Debug\employee.xml");
            foreach (var readAllLine in readAllLines)
            {
                Console.WriteLine(readAllLine);
                
            }
        }

        [Test]
        public void Main()
        {
            try
            {
//                WriteObject("DataContractSerializerExample.xml");
//                ReadObject("DataContractSerializerExample.xml");

//                File.ReadAllLines("DataContractSerializerExample.xml");
            }

            catch (SerializationException serExc)
            {
                Console.WriteLine(@"Serialization Failed");
                Console.WriteLine(serExc.Message);
            }
            catch (Exception exc)
            {
                Console.WriteLine(
                    @"The serialization operation failed: {0} StackTrace: {1}",
                    exc.Message, exc.StackTrace);
            }

            finally
            {
                Console.WriteLine(@"Press <Enter> to exit....");
                Console.ReadLine();
            }
        }

        public static void WriteObject(string fileName)
        {
            Console.WriteLine(
                @"Creating a Person object and serializing it.");
            //            Person p1 = new Person("Zighetti", "Barbara", 101);
            Employee p1 = new Employee { First = "Simon", Second = "Markey" };
            FileStream writer = new FileStream(fileName, FileMode.Create);
            DataContractSerializer ser = new DataContractSerializer(typeof(Employee));
            ser.WriteObject(writer, p1);
            writer.Close();
        }

        public static void ReadObject(string fileName)
        {
            Console.WriteLine(@"Deserializing an instance of the object.");
            FileStream fs = new FileStream(fileName,
                FileMode.Open);
            XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer ser = new DataContractSerializer(typeof(Employee));

            // Deserialize the data and read it from the instance.
            Employee deserializedPerson =
                (Employee)ser.ReadObject(reader, true);
            reader.Close();
            fs.Close();
            Console.WriteLine(@"{0} {1}", deserializedPerson.First, deserializedPerson.Second);
        }
    }
}