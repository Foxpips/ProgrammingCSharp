using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MSExamTests.Chapter1
{
    public class TaskRunner
    {
        [Test]
        public void Run()
        {
            var t = Task.Run(() => 42).ContinueWith((i) => Console.WriteLine(i.Result*2));

            var startNew = new TaskFactory().StartNew(() => 42).ContinueWith(i => Console.WriteLine(i.Result*2));

            var continueWith = new Task<int>(() => 42).ContinueWith(i => Console.WriteLine(i.Result*2));

            continueWith.Start();
            Thread.Sleep(1000);
        }


        [Test]
        public void RunContinuation_Scenario_Result()
        {
            Task<int> t = Task.Run(() =>
            {
                var cancellationTokenSource = new CancellationTokenSource();
                cancellationTokenSource.Cancel();
                cancellationTokenSource.Token.ThrowIfCancellationRequested();
                Console.WriteLine("42");
                return 0;
            });
            
            t.ContinueWith((i) =>
            {
                Console.WriteLine("Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);

            t.ContinueWith((i) =>
            {
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);
            
            var completedTask = t.ContinueWith((i) => { Console.WriteLine("Completed"); },TaskContinuationOptions.OnlyOnRanToCompletion);
            completedTask.Wait();
        }
    }
}