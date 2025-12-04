// See https://aka.ms/new-console-template for more information
using ListImplementation.Models;

Console.WriteLine("Hello, World!");

var ourListImpl = new KhList<string>();

ourListImpl.Add("Hello!");

ourListImpl.Add("Good Mornings!");

var removed = ourListImpl.Remove("Hello!");
Console.WriteLine(removed);

Func<string, string> toUpper = (sentence) => sentence.ToUpper();

ourListImpl.Change("Good Mornings!", toUpper);

var removedChanged = ourListImpl.Remove("GOOD MORNINGS!");

Console.WriteLine(removedChanged);
