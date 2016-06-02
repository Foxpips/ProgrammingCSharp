using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using System.Xml;
using NUnit.Framework;

namespace ProgrammingTests.FileReaderTests
{
    public class TestFileReader : FileReaderTester
    {

        [Test]
        public void Ctor_Scenario_Result()
        {
            var transactionScope = new TransactionScope();

            transactionScope.Complete();
            new TestFileReader();
        }
    }

    public class FileReaderTester
    {
        private const string Path = @"C:\Users\SimonMarkey\Documents\Visual Studio 2012\Projects\SealedClassMocking\SealedClassMocking\TestItems\Test.txt";

        [Test]
        public void File_Reader_Test()
        {
            var htmlString = GetHtmlString();
            Console.WriteLine(htmlString);
        }

        [Test]
        public void BinaryReader_Scenario_Result()
        {
            using (var binaryReader = new BinaryReader(File.OpenRead(Path)))
            {
                for (var i = 0; i < 5; i++)
                {
                    var readBytes = binaryReader.ReadBytes(i);
                    Console.WriteLine(Encoding.UTF8.GetString(readBytes));
                }
            }

        }

        private static HtmlString GetHtmlString()
        {
            var stringBuilder = new StringBuilder();
            var writer = XmlWriter.Create(stringBuilder);
            writer.WriteStartElement("book");
            writer.WriteElementString("price", "19.95");
            writer.WriteEndElement();
            writer.Flush();

            writer.Dispose();
            Console.WriteLine(stringBuilder.ToString());

            FileStream fileStream = File.OpenWrite(Path);
            fileStream.Write(Encoding.UTF8.GetBytes(stringBuilder.ToString()), 0, stringBuilder.Length);
            fileStream.Dispose();


            using (var reader = File.OpenText(Path))
            {
                return new HtmlString(reader.ReadToEnd());
            }
        }

        [Test]
        public void TestArray_Scenario_Result()
        {
            var strings = new[] { "Acme", "WB", "Universal" };
            Console.WriteLine(strings.Length);
            Console.WriteLine(strings.Rank);
            Console.WriteLine(strings.GetLength(0));
            Console.WriteLine(strings.GetUpperBound(0));
            Console.WriteLine(strings.Count());
            
        }
    }
}