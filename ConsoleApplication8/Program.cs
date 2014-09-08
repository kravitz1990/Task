using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Reflection;
using System.Security;

namespace ConsoleApplication7
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "Task";

            const int iterations = 100000000;
            const int numTaks = 1;
            List<Task> tasks = new List<Task>();
          
            int value = 0;

            for (int nTask = 0; nTask < numTaks; nTask++)
            {
                Task t = Task.Factory.StartNew(() =>
                {
                    IncrementValue(ref value, iterations);

                });

                tasks.Add(t);
            }


            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Expected : {0}, Actual : {1}", numTaks * iterations, value);
            Console.ReadKey();
                        
            }

        private static void IncrementValue(ref int value, int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                value++;
            }
        }
    }
}
