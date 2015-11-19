using System;
using System.IO;
using System.Web;
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
            string path =
                @"C:\Users\SimonMarkey\Documents\Visual Studio 2012\Projects\SealedClassMocking\SealedClassMocking\TestItems\Test.txt";
            using (var reader = File.OpenText(path))
            {
                return new HtmlString(reader.ReadToEnd());
            }
        }
    }
}