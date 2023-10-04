using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fae.app
{
    public interface IRunnable
    {
        public string Status { get; }
        public CancellationToken Token { get; }
        Task<IRunnable> RunAsync();
    }
}
