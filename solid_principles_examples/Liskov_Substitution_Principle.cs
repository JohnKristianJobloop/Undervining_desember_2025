using System;

namespace solid_principles_examples;

public class Liskov_Substitution_Principle
{
    public static void Run()
    {
        var eagle = new Eagle();

        var penguin = new Penguin();

        MakeBirdsFly(eagle);

        /* MakeBirdsFly(penguin); */
    }
    public static void MakeBirdsFly(BirdWithFlight bird) => bird.Fly();
}

public class Bird
{
    
}

public class BirdWithFlight: Bird
{
    public virtual void Fly() => Console.WriteLine("Flapping my wings!");
}

public class Eagle: BirdWithFlight
{
    public override void Fly() => Console.WriteLine("Soaring above the forest, looking for small prey.");
}

public class Penguin: Bird
{
    
}
