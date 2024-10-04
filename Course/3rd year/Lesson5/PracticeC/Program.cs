namespace PracticeC;

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
        Console.WriteLine("Выберите фигуру: 1 - Круг, 2 - Прямоугольник, 3 - Треугольник");
        int choice = int.Parse(Console.ReadLine());

        Shape shape = null;

        switch (choice)
        {
            case 1:
                Console.WriteLine("Введите радиус круга:");
                double radius = double.Parse(Console.ReadLine());
                shape = new Circle(radius);
                break;
            case 2:
                Console.WriteLine("Введите ширину и высоту прямоугольника (через пробел):");
                var dimensions = Console.ReadLine().Split(' ');
                double width = double.Parse(dimensions[0]);
                double height = double.Parse(dimensions[1]);
                shape = new Rectangle(width, height);
                break;
            case 3:
                Console.WriteLine("Введите длины сторон треугольника (через пробел):");
                var sides = Console.ReadLine().Split(' ');
                double sideA = double.Parse(sides[0]);
                double sideB = double.Parse(sides[1]);
                double sideC = double.Parse(sides[2]);
                shape = new Triangle(sideA, sideB, sideC);
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                return;
        }

        Console.WriteLine($"Площадь: {shape.GetArea()}");
        Console.WriteLine($"Периметр: {shape.GetPerimeter()}");

        if (shape is Circle circle)
        {
            Console.WriteLine($"Диаметр: {circle.GetDiameter()}");
        }
    }
}
