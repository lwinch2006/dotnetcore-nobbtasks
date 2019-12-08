using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dka.DotNetCore.NobbTasks.TaskB
{
    public class ActionExecutor
    {
        public IEnumerable<Func<Task>> Actions { get; set; }
        
        public ActionExecutor()
        {}
        
        public ActionExecutor(IEnumerable<Func<Task>> actions)
        {
            Actions = actions;
        }

        public async Task ExecuteActions()
        {
            if (Actions == null)
            {
                return;
            }

            var localActions = Actions.ToList();
            
            foreach (var action in localActions)
            {
                await action();
            }
        }
    }
}