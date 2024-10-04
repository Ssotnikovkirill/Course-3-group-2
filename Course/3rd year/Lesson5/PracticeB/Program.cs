namespace PracticeB;

public abstract class Shape
{
    public abstract double Area { get; }

    public abstract double GetArea();

    public abstract double GetPerimeter();
}
public class Circle : Shape
{
    private double radius;
    public Circle(double radius)
    {
        this.radius = radius;
    }

    public override double Area => GetArea();

    public override double GetArea()
    {
        return Math.PI * radius * radius;
    }

    public override double GetPerimeter()
    {
        return 2 * Math.PI * radius;
    }

    public double GetDiameter()
    {
        return 2 * radius;
    }

}

public class Triangle : Shape
{
    double sideA;
    double sideB;
    double sideC;

    public Triangle(double sideA, double sideB, double sideC)
    {
        this.sideA = sideA;
        this.sideB = sideB;
        this.sideC = sideC;
    }

    public override double Area
    {
        get
        {
            double p = (sideA + sideB + sideC) / 2;
            return Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
        }
    }

    public override double GetArea()
    {
        return Area;
    }

    public override double GetPerimeter()
    {
        return sideA + sideB + sideC;
    }
}


public class Rectangle : Shape
{
    double w;
    double h;

    public Rectangle(double w, double h)
    {
        this.w = w;
        this.h = h;
    }

    public override double Area => GetArea();

    public override double GetArea()
    {
        return w * h;
    }

    public override double GetPerimeter()
    {
        return 2 * (w + h);
    }
}


class Program
{
    static void Main(string[] args)
    {
        Circle circle = new Circle(5);
        Console.WriteLine($"Площадь круга: {circle.GetArea()}");

        Rectangle rectangle = new Rectangle(4, 6);
        Console.WriteLine($"Площадь прямоугольника: {rectangle.GetArea()}");

        Triangle triangle = new Triangle(3, 4, 5);
        Console.WriteLine($"Площадь треугольника: {triangle.GetArea()}");
    }
}
