using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using NUnit.Framework;

namespace MSExamTests
{
    public class Moose
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class SerializerTests
    {
        public IEnumerable<Task> Execute(Action[] jobs)
        {
            var length = jobs.Length;
            Task[] tasks = new Task[length];

            for (int i = 0; i < length; i++)
            {
                tasks[i] = new Task((idx) => RunJob(jobs[(int)idx], (int)idx), i);
                tasks[i].Start();
            }
            Task.WaitAll(tasks);

            return tasks;
        }

        public void RunJob(Action job, int index)
        {
            Console.WriteLine(index);
            job();
        }


        

        [Test]
        public void JobTests_Scenario_Result()
        {
            var action = new Action(() => Console.WriteLine("Hi"));
            var action2 = new Action(() => Console.WriteLine("Hi 2"));
            var action3 = new Action(() => Console.WriteLine("Hi 3"));
            var action4 = new Action(() => Console.WriteLine("Hi"));
            Execute(new[] { action, action2, action3 });
        }


        [Test]
        public void IncorrectArrayList_Scenario_Result()
        {
            var arrayList = new ArrayList();
            int var1 = 10;
            int var2;
            arrayList.Add(var1);
            var2 = Convert.ToInt32(arrayList[0]);
            Console.WriteLine(var2);
        }

        [Test]
        public void TaskTEsts_Scenario_Result()
        {
            var tasks = new[] { Task.Factory.StartNew(() => Console.WriteLine(@"Hello")) };

            var task = new Task(Console.WriteLine);
        }

        [Test]
        public void SerializerTests_Scenario_Result()
        {
            var jsSerializer = new JavaScriptSerializer();
            var moose = new Moose { Name = "Gerald", Age = 22 };

            var serialize = jsSerializer.Serialize(moose);
            var s = Serialize(moose);

            Console.WriteLine(s);
            Console.WriteLine(serialize);


            Console.WriteLine(jsSerializer.Deserialize<Moose>(serialize).Name);
            Console.WriteLine(jsSerializer.Deserialize<Moose>(s).Name);


            Moose deserialize = Deserialize<Moose>(s);

            Console.WriteLine();
            Console.WriteLine(deserialize.Name);

            //            var jsonSerializer = new JsonSerializer();
        }

        public static string Serialize<T>(T obj, SerializerTypeEnum type = SerializerTypeEnum.Json) where T : new()
        {
            using (var memoryStream = new MemoryStream())
            using (var reader = new StreamReader(memoryStream))
            {
                XmlObjectSerializer serializer;
                switch (type)
                {
                    case SerializerTypeEnum.Json:
                        serializer = new DataContractJsonSerializer(obj.GetType());
                        break;
                    case SerializerTypeEnum.Xml:
                        serializer = new DataContractSerializer(obj.GetType());
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("type", type, @"Invalid enum entered");
                }

                serializer.WriteObject(memoryStream, obj);
                memoryStream.Position = 0;

                return reader.ReadToEnd();
            }
        }

        public static T Deserialize<T>(string xml, SerializerTypeEnum type = SerializerTypeEnum.Json) where T : class
        {
            var objectType = typeof(T);

            using (Stream stream = new MemoryStream())
            {
                var data = System.Text.Encoding.UTF8.GetBytes(xml);
                stream.Write(data, 0, data.Length);
                stream.Position = 0;

                XmlObjectSerializer deserializer;
                switch (type)
                {
                    case SerializerTypeEnum.Json:
                        deserializer = new DataContractJsonSerializer(objectType);
                        break;
                    case SerializerTypeEnum.Xml:
                        deserializer = new DataContractSerializer(objectType);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("type", type, @"Invalid enum entered");
                }

                return deserializer.ReadObject(stream) as T;
            }
        }

        [Test]
        public void Method_Scenario_Result()
        {
            var s = SerializerTypeEnum.Data | SerializerTypeEnum.Json;

            Console.WriteLine(s);
        }
    }


    [Flags]
    public enum SerializerTypeEnum
    {
        Json =1,
        Xml =2,
        Data =4,
        Plaintext =8
    }
}