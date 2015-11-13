using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using NUnit.Framework;

namespace MSExamTests.Chapter1
{
    public class TaskFactorySimon
    {
        [Test]
        public void Method_Scenario_Result()
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];
                TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent,TaskContinuationOptions.ExecuteSynchronously);

                tf.StartNew(() => results[0] = 0);
                tf.StartNew(() => results[1] = 1);
                tf.StartNew(() => results[2] = 2);
                
                return results;
            });
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var finalTask = parent.ContinueWith(parentTask =>
            {
                parentTask.Result.Each(Console.WriteLine);
            });

//            Thread.Sleep(TimeSpan.FromSeconds(1));
            finalTask.Wait();
        }

        [Test]
        public void WaitAll_Scenario_Result()
        {
            var tasks = new Task[2];

            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Task 1");
            });
            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Task 2");
            });


            Task.WaitAny(tasks);
            Console.WriteLine("finished");
        }
    }
}