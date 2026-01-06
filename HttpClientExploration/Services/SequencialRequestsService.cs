using System;
using System.Diagnostics;

namespace HttpClientExploration.Services;

public class SequencialRequestsService : BaseService
{
    public async Task SendGetRequestsSequentianWithStopwatch(IEnumerable<string> endpoints, HttpClient client)
    {
        var stopwatch = Stopwatch.StartNew();
        foreach (var endpoint in endpoints)
        {
            await FetchFromEndpoint(endpoint, client);
        }
        stopwatch.Stop();
        Console.WriteLine($"Sequential operation took: {stopwatch.ElapsedMilliseconds}ms to complete..");
    }
}
