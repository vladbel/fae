using fae.app;
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
        public string Status => throw new NotImplementedException();

        public CancellationToken Token => throw new NotImplementedException();

        public async Task<IRunnable> RunAsync()
        {
            string[] exitInput = { "ex", "exit", "quit", "q" };

            while (true)
            {
                var input = await Task.Run(() => Console.ReadLine());
                if (exitInput.Contains(input))
                {
                    break;
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
