using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace fae.console
{
    public class InputHandler
    {

        public async Task<string> Run()
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

            return "OK";
        }



    }
}
