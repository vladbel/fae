using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fae.app
{
    public class BaseWorkItem : IRunnable
    {
        public string Id { get; private set; }

        public CancellationToken Token { get; private set; }


        public BaseWorkItem( string id)
        {
            Id = id;
        }

        public async Task<IRunnable> RunAsync()
        {
            Console.WriteLine ($"Task id = {Id} started.");
            await Task.Delay(1000);
            Console.WriteLine($"Task id = {Id} completed" +
                $".");
            return this;
        }
    }
}
