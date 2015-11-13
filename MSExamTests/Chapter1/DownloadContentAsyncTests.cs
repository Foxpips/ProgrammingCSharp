using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;
using NUnit.Framework;

namespace MSExamTests.Chapter1
{
    public class DownloadContentAsyncTests
    {
        [Test]
        public void Method_Scenario_Result()
        {
            var result = DownloadContent();
            
            
            Console.WriteLine(@"Some Work");
          
            Console.WriteLine(result.Result);
            Console.WriteLine(@"finsihed");
        }

        private static async Task<string> DownloadContent()
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync("http://www.mywelfare.ie");
            }
        }
    }
}