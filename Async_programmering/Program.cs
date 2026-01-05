// See https://aka.ms/new-console-template for more information
using Async_programmering.Models;
using Async_programmering.Services;
/*
var newThread = new Thread(DoActionOnNewThread);
newThread.Start();

for (int i = 1000; i >= 0; i--)
{
    Thread.Sleep(20);
    Console.WriteLine(i);
}

Console.WriteLine("Hello, world!");


static void DoActionOnNewThread()
{
   for (int i = 0; i < 1000; i++)
    {
        Thread.Sleep(20);
        Console.WriteLine(i);
    } 
}
*/


var counter1 = new Counter("Counter 1", 10, 100);
var counter2 = new Counter("Counter 2", 5, 200);

var counter3 = new Counter("Counter 3", 8, 80);
var counter4 = new Counter("Counter 4", 12, 400);

var counter5 = new Counter("Counter 5", 4, 200);
var counter6 = new Counter("Counter 6", 20, 20);

var source = new CancellationTokenSource();

var threads = CountWithThreadsService.CountCountersUsingThreads([counter1, counter2]);

var task = CountWithTaskCompletionSource.CountCountersWithTask([counter3, counter4], source.Token);

var asyncTask = CountWithAsyncAwait.CountCountersUsingAsyncAwait([counter5, counter6]);

var awaiter = Task.Delay(500).GetAwaiter();
awaiter.OnCompleted(source.Cancel);

foreach(var thread in threads) thread.Join();
task.Wait();

await asyncTask;
/*
----Main() -> create thread -> "Hello World!" -> exit----
                            \ -> for loop -> /

*/