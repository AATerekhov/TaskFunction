using System.Diagnostics;
using TaskFunction.Handler;
using TaskFunction.Scheduler;

namespace TaskFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string startDirectory = "C:\\Users\\User\\source\\repos\\OTUS\\22_Введение в параллелизм\\Task";
            StartProgram(startDirectory);
        }
        static void StartProgram(string startDirectory)
        {
            static IScheduler GetScheduler(string startDirectory)
            {
                return new TasksScheduler(startDirectory);
            }
            var scheduler = GetScheduler(startDirectory);

            MeasureTime(scheduler, FileHandlerFactory.GetCountSpace);
            MeasureTime(scheduler, FileHandlerFactory.GetCountSpaceAsync);    
        }

        private static void MeasureTime(IScheduler scheduler, HandlerFuctory handlerFuctory)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            scheduler.ProcessQueue(handlerFuctory);
            stopWatch.Stop();
            Console.WriteLine($"Время многопоточной работы программы: {stopWatch.Elapsed}...");
            foreach (var item in scheduler.GetRezult())
            {
                Console.WriteLine(item);
            }
        }
    }
}
