using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProgrammingTests.Async
{
    internal class Program
    {
        public static void Main()
        {
            //Create a new Service
            var maintenanceService = new MaintenanceService();

            //Add a task to a new tasks list
            Task<bool> maintenanceTask1 = maintenanceService.CheckisMaintenance();
//            Console.WriteLine(maintenanceTask1.Result);
            var tasks = new List<Task> {maintenanceTask1};

            //Sleep in order to separate tasks by 1 second
            Thread.Sleep(TimeSpan.FromSeconds(1));

            //Add another task to the list
            var maintenanceTask2 = maintenanceService.CheckisMaintenance();
            tasks.Add(maintenanceTask2);

            //Meanwhile allow the user to type away
            while (true)
            {
                var line = Console.ReadLine();

                if (line != null && line.Equals("quit"))
                {
                    break;
                }
            }

            //Finally ensure every task has finished exectuing before quitting
            foreach (var task in tasks)//.Where(task => !task.IsCompleted))
            {
                task.Wait();
            }

            //Get the result of the boolean task1 methods
            Console.WriteLine("Maintenance Mode for task1:");
            Console.WriteLine(maintenanceTask1.Result);

            Console.WriteLine("\n");

            //Get the result of the boolean task2 method
            Console.WriteLine("Maintenance Mode task2:");
            Console.WriteLine(maintenanceTask2.Result);

            Console.WriteLine("Application Closing..");
        }
    }

    public class MaintenanceService
    {
        public async Task<bool> CheckisMaintenance()
        {
            // RunAsync will run Asynchronously while RuncSync will run the task synchronously..

            // If the Async version is not awaited then it will not wait 
            // for the tasks to finished completing before continuing 
            // when you type quit

            return await RunAsyncMethod();
            //return RunSyncMethod();
        }

        private static bool RunSyncMethod()
        {
            //Mimic some work that will take some time to execute synchronously.
            Console.WriteLine("Starting execution of a syncrhonous task");
            for (var i = 0; i < 5; i++)
            {
                int counter2;

                for (counter2 = 0; counter2 < 1000000000; counter2++)
                {
                    counter2++;
                }
                Console.WriteLine("\n Checking Maintenance..");
            }
            return true;
        }

        private static async Task<bool> RunAsyncMethod()
        {
            //Mimic some work that will take some time to execute asynchronously.
            Console.WriteLine("Starting execution of an asyncrhonous task");
            for (var i = 0; i < 5; i++)
            {
                int counter;
                await Task.Run(() =>
                {
                    for (counter = 0; counter < 1000000000; counter++)
                    {
                        counter++;
                    }
                });
                Console.WriteLine("\n Checking Maintenance..");
            }
            return true;
        }
    }
}