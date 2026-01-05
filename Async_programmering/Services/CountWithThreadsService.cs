using System;
using Async_programmering.Models;

namespace Async_programmering.Services;

public static class CountWithThreadsService
{
    public static List<Thread> CountCountersUsingThreads(IEnumerable<Counter> counters)
    {
        List<Thread> threads = [];
        foreach (var counter in counters)
        {
            var thread = new Thread(DoActionWithCounterOnthread);
            thread.Start(counter);
            threads.Add(thread); 
        }  
        return threads;
    }
    private static void DoActionWithCounterOnthread(object? state)
    {
        var counter = (Counter)state!;
        Console.WriteLine($"Counter {counter.Name} stated on thread.");
        for (int i = 0; i < counter.MaxCount; i++)
        {
            Thread.Sleep(counter.DelayInMs);
            Console.WriteLine($"{counter.Name} has counted {i + 1} times out of {counter.MaxCount}");
        }

        Console.WriteLine($"{counter.Name} has finished...");
    }
}
