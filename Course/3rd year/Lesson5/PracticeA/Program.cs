namespace PracticeA;

public abstract class Shape
{
    public abstract double Area { get; }

    public abstract double GetArea();

    public abstract double GetPerimeter();
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
