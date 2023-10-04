namespace fae.app
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/start-multiple-async-tasks-and-process-them-as-they-complete
    /// </summary>
    public class Runner
    {
        private List<IRunnable> _pending = new List<IRunnable>();
        private List<Task<IRunnable>> _running = new List<Task<IRunnable>>();
        private List<IRunnable> _completed = new List<IRunnable>();

        public string AddTask( IRunnable workItem)
        {
            var runningTask = workItem.RunAsync();
            _running.Add(runningTask);
            return $"Work Item added. Running tasks: {_running.Count} ";
        }

        public async Task<string> RunAsync()
        {

            while (_running.Any())
            {
                var finishedTask = await Task.WhenAny(_running);
                _running.Remove(finishedTask);

                var completedWorkItem = await finishedTask;
                _completed.Add(completedWorkItem);
            }

            return "All tasks completed.";
        }
    }
}