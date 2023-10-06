using fae.app.Interfaces;

namespace fae.app
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/start-multiple-async-tasks-and-process-them-as-they-complete
    /// </summary>
    public class Runner : IRunner
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<string> RunAsync()
        {
            while (_running.Any())
            {
                var completedTasks = _running.Where( task =>  task.IsCompleted ).ToList();
                _running.RemoveAll(task => task.IsCompleted);

                foreach ( var task in completedTasks )
                {
                    var completedWorkItem = await task;
                    _completed.Add(completedWorkItem);
                    Console.WriteLine($"Completed task handled by Runner: ID = {completedWorkItem.Id}");
                }

                await Task.Delay(500);
            }

            return "All tasks completed.";
        }
    }
}