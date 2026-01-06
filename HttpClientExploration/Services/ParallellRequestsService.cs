using System;
using System.Diagnostics;

namespace HttpClientExploration.Services;

public class ParallellRequestsService : BaseService
{
    public async Task ParallellRequestsToEnpoints(IEnumerable<string> endpoints, HttpClient client)
    {
        var stopwatch = Stopwatch.StartNew();

        List<Task> tasks = [..endpoints.Select(endpoint => FetchFromEndpoint(endpoint, client))];

        await Task.WhenAll(tasks);

        stopwatch.Stop();

        Console.WriteLine($"Parallell operation took {stopwatch.ElapsedMilliseconds}ms...");
    }
}
