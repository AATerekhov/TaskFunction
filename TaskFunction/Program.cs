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

    MeasureTime(GetScheduler(startDirectory), FileHandlerFunction.GetCountSpaceAsync);
    MeasureTime(GetScheduler(startDirectory), FileHandlerFunction.GetCountSpace);
}

void MeasureTime(IScheduler scheduler, HandlerFunction handlerFuctory)
{
    var stopWatch = new Stopwatch();
    stopWatch.Start();
    scheduler.ProcessQueue(handlerFuctory);
    scheduler.GetResult().ToList().ForEach(c => Console.WriteLine(c));
    stopWatch.Stop();
    Console.WriteLine($"Время многопоточной работы программы: {stopWatch.Elapsed}.");
}
