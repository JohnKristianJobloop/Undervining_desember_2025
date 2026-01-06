using System;

namespace HttpClientExploration.Services;

public class BaseService
{
    public async Task FetchFromEndpoint(string endpoint, HttpClient client)
    {
        try
        {
            var response = await client.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Recieved {content} from {endpoint}....");
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Something went wrong when reading from {endpoint}: {e.Message}");
        }
    }
}
