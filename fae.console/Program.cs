using System;
using fae.app;

namespace fae.console
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Console started ...");

            var runner = new Runner();
            var inputHandler = new InputHandler( runner);

            var result = runner.AddTask(inputHandler);
            Console.WriteLine($"Add to runner Input handler: {result}");

            result = await runner.RunAsync();

            Console.WriteLine($"Runner completed: {result}");
            Console.WriteLine("Console end ...");
        }
    }
}
