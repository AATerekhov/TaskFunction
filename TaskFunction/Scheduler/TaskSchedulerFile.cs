using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFunction.Scheduler
{
    public class TaskSchedulerFile(string filePath)
    {
        public string FilePath { get; set; } = filePath;
        public Task<int>? Task { get; set; }
        public int CountSpace => Task.Result;
    }
}
