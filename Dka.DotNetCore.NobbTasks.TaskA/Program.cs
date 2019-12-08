using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dka.DotNetCore.NobbTasks.TaskA
{
    class Program
    {
        private static void Main(string[] args)
        {
            var actions = new List<Func<Task>>
            {
                async () => { Console.WriteLine("Action 1 executed"); await Task.Delay(1000); },
                async () => { Console.WriteLine("Action 2 executed"); await Task.Delay(1000); },
                async () => { Console.WriteLine("Action 3 executed"); await Task.Delay(1000); },
                async () => { Console.WriteLine("Action 4 executed"); await Task.Delay(1000); }
            };
            
            var actionExecutor = new ActionExecutor(actions);

            ((List<Func<Task>>)actionExecutor.Actions).Add(async () => { Console.WriteLine("Action 5 executed"); await Task.Delay(1000); });
            
            var t = Task.Run(async () =>
            {
                await actionExecutor.ExecuteActions();
                ((List<Func<Task>>)actionExecutor.Actions).Clear();
            });
            
            for (var i = 1; i < 100; i++)
            {
                Console.WriteLine($"Here goes another activity: [{i.ToString()}]");
                
                Thread.Sleep(50);
            }

            t.Wait();
        }
    }
}