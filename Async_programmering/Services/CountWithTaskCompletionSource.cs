using System;
using Async_programmering.Models;
using Microsoft.VisualBasic;

namespace Async_programmering.Services;

public static class CountWithTaskCompletionSource
{
    public static Task<bool> CountCountersWithTask(IEnumerable<Counter> counters, CancellationToken token)
    {
        var masterTsc = new TaskCompletionSource<bool>();
        List<Task> tasks = [];

        foreach (var counter in counters)
        {
            tasks.Add(CountSingleCounter(counter,token));
        }
        Task.WhenAll(tasks).ContinueWith(allTasks =>
        {
            masterTsc.SetResult(true);
        });
        return masterTsc.Task;
    }

    private static Task CountSingleCounter(Counter counter, CancellationToken token)
    {
        var tsc = new TaskCompletionSource();

        Task.Run(()=>
        {
            Console.WriteLine($"{counter.Name} is starting the count");

            CountSingleCounterInLoop(counter, tsc, token);
        });
        return tsc.Task;
    }

    private static void CountSingleCounterInLoop(Counter counter, TaskCompletionSource tsc, CancellationToken token)
    {
        int currentCount = 0;

        void CountContinuation()
        {
            if (token.IsCancellationRequested)
            {
                return;
            }
            ;
            if (currentCount < counter.MaxCount)
            {
                var delayTask = Task.Delay(counter.DelayInMs);
                var awaiter = delayTask.GetAwaiter();

                awaiter.OnCompleted(() =>
                {
                    Console.WriteLine($"{counter.Name} has counted {currentCount + 1} our of {counter.MaxCount}");
                    currentCount++;
                    CountContinuation();
                });
            }
            else
            {
                Console.WriteLine($"{counter.Name} has completed...");
                tsc.SetResult();
            }
        }

        CountContinuation();
    }
}
