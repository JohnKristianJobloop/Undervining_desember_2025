using System;

namespace solid_principles_examples;

public class Interface_Segregation_Principle
{
    public void Run()
    {
        IPrintable printer = new SimpleLaserPrinter();

        printer.Print("Hello!");

    }
}
public interface IPrinter
{
    void Print(string text);

    string Scan();

    void Fax(int faxNumber);
}

public interface IPrintable
{
    void Print(string Text);
}

public interface IScannable
{
    string Scan();
}

public interface IFaxable
{
    void Faxt(int number);
}

public class SimpleLaserPrinter : IPrintable
{

    public void Print(string text)
    {
        Console.WriteLine(text);
    }

}