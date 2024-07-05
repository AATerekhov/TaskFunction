using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFunction.Scheduler
{
    public class TaskSchedulerFile
    {
        public TaskSchedulerFile(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; set; }
        public Task<int> Task { get; set; }
        public int countSpace { get { return Task.Result; } }
    }
}
