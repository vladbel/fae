using System;
using fae.app;

namespace fae.console
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Console started ...");

            var inputHandler = new InputHandler();
            var result = await inputHandler.Run();

            Console.WriteLine("Console end ...");
        }
    }
}
