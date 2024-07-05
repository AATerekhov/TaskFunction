using System.Diagnostics;
using TaskFunction.Handler;
using TaskFunction.Scheduler;

string startDirectory = "C:\\Users\\User\\source\\repos\\OTUS\\22_Введение в параллелизм\\Task";
StartProgram(startDirectory);
void StartProgram(string startDirectory)
{
    static IScheduler GetScheduler(string startDirectory)
    {
        return new TasksScheduler(startDirectory);
    }

    MeasureTime(GetScheduler(startDirectory), FileHandlerFactory.GetCountSpaceAsync);
    MeasureTime(GetScheduler(startDirectory), FileHandlerFactory.GetCountSpace);
}

void MeasureTime(IScheduler scheduler, HandlerFuctory handlerFuctory)
{
    var stopWatch = new Stopwatch();
    stopWatch.Start();
    scheduler.ProcessQueue(handlerFuctory);
    scheduler.GetRezult().ToList().ForEach(c => Console.WriteLine(c));
    stopWatch.Stop();
    Console.WriteLine($"Время многопоточной работы программы: {stopWatch.Elapsed}.");
}
