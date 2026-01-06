// See https://aka.ms/new-console-template for more information

using HttpClientExploration.Services;


await Task.Delay(200);
var parallellService = new ParallellRequestsService();
var sequentialService = new SequencialRequestsService();

var client = new HttpClient();

List<string> endpoints = [
    "https://icanhazdadjoke.com/slack",
    "https://official-joke-api.appspot.com/random_joke",
    "https://api.chucknorris.io/jokes/random"
];

await sequentialService.SendGetRequestsSequentianWithStopwatch(endpoints, client);

await parallellService.ParallellRequestsToEnpoints(endpoints, client);

