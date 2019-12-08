using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Dka.DotNetCore.NobbTasks.TaskB
{
    class Program
    {
        private static void Main(string[] args)
        {
            var actions = new List<Func<Task>>();

            var currentDirectory = Directory.GetCurrentDirectory();

            for (var i = 1; i < 5; i++)
            {
                var fileNumber = i;
                actions.Add(
                    async () =>
                    {
                        Console.WriteLine($"File {fileNumber.ToString()} saved.");
                        await File.WriteAllLinesAsync(Path.Combine(currentDirectory, $"file-{fileNumber.ToString()}.txt"),
                            new[] {DateTime.Now.ToString()});
                        await Task.Delay(1000);
                    });
            }

            var actionExecutor = new ActionExecutor(actions);

            var t = Task.Run(async () =>
            {
                await actionExecutor.ExecuteActions();
                ((List<Func<Task>>) actionExecutor.Actions).Clear();
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