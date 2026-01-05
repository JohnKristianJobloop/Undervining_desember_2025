using System;
using Async_programmering.Models;

namespace Async_programmering.Services;

public static class CountWithAsyncAwait
{
    public static async Task CountCountersUsingAsyncAwait(IEnumerable<Counter>counters)
    {
        List<Task> tasks = [];

        foreach (var counter in counters)
        {
            tasks.Add(CountCounterAsync(counter));
        }

        await Task.WhenAll(tasks);
    }
    private static async Task CountCounterAsync(Counter counter)
    {
        Console.WriteLine($"{counter.Name} starting count....");
        for (int i = 0; i < counter.MaxCount; i++)
        {
            await Task.Delay(counter.DelayInMs);
            Console.WriteLine($"{counter.Name} has counter {i+1} times out of {counter.MaxCount}");
        }
        Console.WriteLine($"{counter.Name} is finito");
    }
}
