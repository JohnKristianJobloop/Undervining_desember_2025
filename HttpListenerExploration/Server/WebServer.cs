using System;
using System.Data;
using System.Net;
using System.Text;

namespace HttpListenerExploration.Server;

public class WebServer
{
    private HttpListener _listener;
    private string _folder = "./wwwroot";

    public WebServer(string uriPrefix, string? baseFolder)
    {
        _listener = new();
        _listener.Prefixes.Add(uriPrefix);

        if (!string.IsNullOrWhiteSpace(baseFolder))
        {
            _folder = baseFolder;
        }
    }

    public async Task Start()
    {
        _listener.Start();

        while(true)
        {
            try
            {
                var context = await _listener.GetContextAsync();
                if (context.Request.HttpMethod == "GET") ProcessRequestAsync(context);
                if (context.Request.HttpMethod == "POST") ProcessPostRequestAsync(context);

            }
            catch (HttpListenerException){break;}
            catch (InvalidOperationException){break;}
        }
    }

    public void Stop() => _listener.Stop();

    private async Task ProcessRequestAsync(HttpListenerContext context)
    {
        try
        {
            var fileName = Path.GetFileName(context.Request.RawUrl);
            var filePath = Path.Combine(_folder, fileName!);

            byte[] responseMessage;



            if (!File.Exists(filePath))
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                responseMessage = Encoding.UTF8.GetBytes($"Sorry, {fileName} is not an available path");
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.OK;

                responseMessage = await File.ReadAllBytesAsync(filePath);
            }

            context.Response.ContentLength64 = responseMessage.Length;

            using var outputStream = context.Response.OutputStream;
            await outputStream.WriteAsync(responseMessage);

        } catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error processing request: {ex.Message}");
        }
    }

    public async Task ProcessPostRequestAsync(HttpListenerContext context)
    {
        var response = context.Response;
        var request = context.Request;

        byte[] responseMessage;

        if (!request.HasEntityBody)
        {
            response.StatusCode = (int)HttpStatusCode.BadRequest;

            responseMessage = Encoding.UTF8.GetBytes("Missing body in request");
        }
        else
        {
            var fileName = request.Headers["x-fileName"] ?? $"data-{DateTime.UtcNow}.txt";
            using var memStream = new MemoryStream();

            await request.InputStream.CopyToAsync(memStream);

            var filePath = Path.Combine(_folder, fileName!);

            await File.WriteAllBytesAsync(filePath, memStream.ToArray());

            response.StatusCode = (int)HttpStatusCode.OK;
            responseMessage = Encoding.UTF8.GetBytes($"Saved file at: {filePath}");
        }
        using var outputStream = response.OutputStream;

        await outputStream.WriteAsync(responseMessage);


    }
}
