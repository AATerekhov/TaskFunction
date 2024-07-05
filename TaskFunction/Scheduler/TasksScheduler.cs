using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFunction.Handler;

namespace TaskFunction.Scheduler
{
    public class TasksScheduler(string startDirectory) : IScheduler
    {
        private readonly List<TaskSchedulerFile> _taskFiles = [];
        HandlerFuctory? _handlerFuctory;

        public string StartDirectory { get; set; } = startDirectory;
        public void ProcessQueue(HandlerFuctory handlerFuctory)
        {
            _taskFiles.Clear();
            _handlerFuctory = handlerFuctory;
            foreach (string filename in Directory.EnumerateFiles(StartDirectory))
            {
                _taskFiles.Add(new TaskSchedulerFile(filename));
            }
            _taskFiles.ForEach(file => StartHandlerTask(file));
        }

        private void StartHandlerTask(TaskSchedulerFile item)
        {
            if(_handlerFuctory != null)
            item.Task = Task.Run<int>(()=> _handlerFuctory(item.FilePath));
        }

        public int[] GetRezult() => _taskFiles.Select(f=>f.CountSpace).ToArray();
    }


}
