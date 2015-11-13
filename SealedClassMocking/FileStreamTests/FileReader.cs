using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SealedClassMocking.Extensions;

namespace SealedClassMocking.FileStreamTests
{
    public class FileReader
    {
        private string _getCurrentDirectory;
        private const string TestTxt = @"\Test.txt";

        [SetUp]
        public void SetUp()
        {
            _getCurrentDirectory = Directory.GetCurrentDirectory();

            using (var streamWriter = File.CreateText(_getCurrentDirectory + TestTxt))
            {
                streamWriter.WriteLine("Hello World");
            }
        }

        [Test]
        public void FileStream_Read_FileIsRead()
        {
            var filePaths = Directory.GetFiles(_getCurrentDirectory, "*.txt");
            var filePath = filePaths.FirstOrDefault();
            if (filePath != null)
            {
                var readAllLines = File.ReadAllLines(filePath);
                readAllLines.Each(Console.WriteLine);
            }
        }

        [Test]
        public void StreamReader_Scenario_Result()
        {
            var list = new List<string>();
            using (var streamReader = new StreamReader(_getCurrentDirectory + TestTxt, Encoding.UTF8))
            {
                string str;
                while ((str = streamReader.ReadLine()) != null)
                    list.Add(str);
            }
            list.ToArray().Each(Console.WriteLine);
        }

        [Test]
        public void FileReader_Scenario_Result()
        {
            var dataArray = new byte[100];
            using (var fileStream = new FileStream(_getCurrentDirectory + TestTxt, FileMode.Open, FileAccess.Read))
            {
                for (var i = 0; i < fileStream.Length; i++)
                {
                    var readByte = fileStream.ReadByte();
                    Console.WriteLine(readByte);
                    dataArray[i] = (byte) readByte;
                }
                Console.WriteLine(Encoding.UTF8.GetString(dataArray));
            }
        }
    }
}