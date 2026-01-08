// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Text;
using HttpListenerExploration.Server;



/*
Eksempel på å stegvis lytte etter, bryte ned så skrive en respons og sende i retur:

Console.WriteLine("Hello, World!");
var listener = new HttpListener();

listener.Prefixes.Add("http://localhost:9001/");

listener.Start();

var context = await listener.GetContextAsync();

Console.WriteLine(context.Request.HttpMethod);

Console.WriteLine(context.Request.RawUrl);

string responseMessage = $"You asked for the following resource: {context.Request.RawUrl}\n";

context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(responseMessage);

context.Response.StatusCode = (int)HttpStatusCode.OK;

using var outputStream = context.Response.OutputStream;

using var streamWriter = new StreamWriter(outputStream);

await streamWriter.WriteAsync(responseMessage);

listener.Close();

*/


var server = new WebServer("http://localhost:8990/", null);

try
{
    server.Start();
    Console.WriteLine("Press any key to exit....");
    Console.ReadLine();
}
finally
{
    server.Stop();
}
