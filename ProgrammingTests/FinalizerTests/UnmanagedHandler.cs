using System;
using System.IO;
using NUnit.Framework;
using ProgrammingTests.Extensions;

namespace ProgrammingTests.FinalizerTests
{
    public class UnmanagedHandlerTester
    {
        private const string HelloWorld = "Hello World";

        [Test]
        public void Call_Finalizer_UnmanagedHandler()
        {
            var unmanagedHandler = new UnmanagedHandler();
            unmanagedHandler.WriteToFile(HelloWorld);
            unmanagedHandler.ReadFile();
        }

        [Test]
        public void SuppressFinalize_Call_Dispose()
        {
            using (var unmanagedHandler = new UnmanagedHandler())
            {
                unmanagedHandler.WriteToFile(HelloWorld);
                unmanagedHandler.ReadFile();
            }
        }
    }

    public class UnmanagedHandler : IDisposable
    {
        private readonly FileStream _fileStream;

        public UnmanagedHandler(string fileName = "Test.txt")
        {
            var filePath = string.Concat(Directory.GetCurrentDirectory(), @"\", fileName);
            _fileStream = !File.Exists(filePath)
                ? File.Create(filePath)
                : File.Open(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        public void ReadFile()
        {
            using (var streamReader = new StreamReader(_fileStream))
            {
                _fileStream.Seek(0, SeekOrigin.Begin);
                var s = streamReader.ReadToEnd();
                Console.WriteLine(s);
            }
        }

        public void WriteToFile(string content)
        {
            var byteArray = content.ToByteArray();
            WriteToStream(byteArray);
        }

        private void WriteToStream(byte[] byteArray)
        {
            _fileStream.Write(byteArray, 0, byteArray.Length);
            _fileStream.Flush();
        }

        ~UnmanagedHandler()
        {
            Console.WriteLine("Finalizer call");
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_fileStream != null)
                {
                    _fileStream.Close();
                }
            }
        }
    }
}