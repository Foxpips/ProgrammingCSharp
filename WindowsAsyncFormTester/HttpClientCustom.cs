using System;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;

namespace WindowsAsyncFormTester
{
    public class HttpClientCustom : IDisposable
    {
        public void Dispose()
        {
        }

        public Task<string> Save(bool b)
        {
            if (b)
            {
                var notCompleted = "Not Completed";
                return Task.FromResult(notCompleted);
            }

            Task.Delay(TimeSpan.FromSeconds(2));
            Func<string> act = () =>
            {
                //mimic do work
                Task.Delay(TimeSpan.FromSeconds(3));

                //return completed
                return "Completed";
            };

            return Task.Factory.StartNew(() =>
            {
                //mimic do work
                Task.Delay(TimeSpan.FromSeconds(3));
                
                //return completed
                return "Completed";
            });
        }
    }
}