using fae.app;
using fae.app.Interfaces;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace fae.console
{
    public class InputHandler : IRunnable
    {
        public string Id => throw new NotImplementedException();

        public CancellationToken Token => throw new NotImplementedException();

        private IRunner _runner;
        public InputHandler ( IRunner runner ) 
        { 
            _runner = runner;
        }

        public async Task<IRunnable> RunAsync()
        {
            string[] exitInput = { "ex", "exit", "quit", "q" };
            string[] newTaskInput = { "t", "tsk", "task" };

            while (true)
            {
                var input = await Task.Run(() => Console.ReadLine());
                var inputItems = input.Split(" ");
                if (exitInput.Contains(inputItems[0]))
                {
                    break;
                }
                else if (newTaskInput.Contains(inputItems[0]))
                {
                    var id = inputItems.Length > 1 ? inputItems[1] : "Undefined ID";
                    var newWorkItem = new BaseWorkItem(id);
                    _runner.AddTask(newWorkItem);
                }
                else
                {
                    Console.WriteLine("Unknown input");
                }
            }

            return this;
        }
    }
}
