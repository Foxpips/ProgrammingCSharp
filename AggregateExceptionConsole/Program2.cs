using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AggregateExceptionConsole
{
    public static class Program2
    {
        public static void Main()
        {
            BlockingCollection<string> col = new BlockingCollection<string>();
            Task read = Task.Run(() =>
            {
                while (true)
                {
                    //Console.WriteLine("Taking");
                    col.Add("Removing");
                }
            });

            Task write = Task.Run(() =>
            {
                while (true)
                {
                    string s = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(s)) break;
                    Console.WriteLine("Adding");
                    col.Add(s);
                    col.CompleteAdding();
                    
                }
            });

            write.Wait();
        }
    }
}