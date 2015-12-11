using System;
using System.IO;
using System.Text;
using System.Web;
using System.Xml;
using NUnit.Framework;

namespace ProgrammingTests.FileReaderTests
{
    public class FileReaderTester
    {
        [Test]
        public void File_Reader_Test()
        {
            var htmlString = GetHtmlString();
            Console.WriteLine(htmlString);
        }

        private static HtmlString GetHtmlString()
        {
            var writer = XmlWriter.Create(new StringBuilder());
            writer.WriteStartElement("book");
            writer.WriteElementString("price", "19.95");
            writer.WriteEndElement();
            writer.Flush();

            writer.Dispose();

            string path =
                @"C:\Users\SimonMarkey\Documents\Visual Studio 2012\Projects\SealedClassMocking\SealedClassMocking\TestItems\Test.txt";
            using (var reader = File.OpenText(path))
            {
                return new HtmlString(reader.ReadToEnd());
            }
        }
    }
}