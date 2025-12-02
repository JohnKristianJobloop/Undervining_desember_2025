// See https://aka.ms/new-console-template for more information
using Kodestil_Kodestandarder.Models;

Console.WriteLine("Hello, World!");

HeadPhoneAmp newAmp = new HeadPhoneAmp();

string firstArgument = args[0];


var number = 10;

double number2 = 20;

Dictionary<string, Dictionary<int, Dictionary<string, float>>> keyValuePairs = new();

var secondDictionary = keyValuePairs;

List<string> names = [
    "John",
    "Jørgen",
    "Lars Gunnar"
];

List<string> names2 = new()
{
    "John",
    "Jørgen",
    "Lars Gunnar"
};

//numbers er et array som ser slik ut: [0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
int[] numbers = new int[10];

//numbers2 er et array som ser slik ut: [10]
int[] numbers2 = [10];

for (int i = 0; i < numbers.Length; i++)
{
    numbers[i] = i*i;
}

var found = numbers.Where(number => number == 37).FirstOrDefault(); //default verdien til en int (og alle andre standard verdi typer) er 0

var foundName = names.Where(name => name == "Jakob").FirstOrDefault();

var foundNameToUpper = foundName.ToUpper(); //default verdien av våre reference typer er NULL (ingenting).


/// la oss si vi tar inn tallet 5, og skal se om det er even:
/// 
/// Tallet fem kan representeres slik: 0101
/// Tallet en kan representeres slik: 0001
/// 
/// & variabelen ser på om de har en byte tilfelles, og i så fall hva posisjon. 
/// Siden disse har første posisjon tilfelles, får vi tilbake tallet 1 (0001)
Func<int, bool> isEven = (number) => (number & 1) == 0;

numbers.Where(isEven).ToList().ForEach(Console.WriteLine);


var input = Console.ReadLine();

switch (input)
{
    case "Hello":
        Console.WriteLine("Hello!");
        break;
    default:
        break;
};





