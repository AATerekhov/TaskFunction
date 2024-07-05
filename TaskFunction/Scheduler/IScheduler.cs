using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFunction.Handler;

namespace TaskFunction.Scheduler
{
    public interface IScheduler
    {
        void ProcessQueue(HandlerFuctory handlerFuctory);
        int[] GetRezult();
    }
}
