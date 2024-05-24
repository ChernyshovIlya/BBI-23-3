using System;
using System.Linq;

struct Point
{
    public double X { get; }
    public double Y { get; }

    public Point(double[] coordinates)
    {
        if (coordinates.Length != 2)
        {
            throw new ArgumentException("Надо опять 2 точки хд");
        }
        X = coordinates[0];
        Y = coordinates[1];
    }

    public double DistanceTo(Point other)
    {
        double dx = X - other.X;
        double dy = Y - other.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    public static void PrintInfo(Point p1, Point p2)
    {
        Console.WriteLine($"Точка 1: ({p1.X}, {p1.Y})");
        Console.WriteLine($"Точка 2: ({p2.X}, {p2.Y})");
        Console.WriteLine($"Расстояние между: {p1.DistanceTo(p2)}");
    }
}

abstract class Fourangle
{
    protected readonly Point[] Points;

    protected Fourangle(Point[] points)
    {
        if (points.Length != 4)
        {
            throw new ArgumentException("А теперь надо 4 точки");
        }
        Points = points;
    }

    public abstract double Area();

    public double Perimeter()
    {
        double sum = 0;
        for (int i = 0; i < 4; i++)
        {
            sum += Points[i].DistanceTo(Points[(i + 1) % 4]);
        }
        return sum;
    }

    public override string ToString()
    {
        return $"{GetType().Name} - Периметр: {Perimeter()}, Площадь: {Area()}";
    }
}

class Square : Fourangle
{
    public Square(Point[] points) : base(points) { }

    public override double Area()
    {
        double side = Points[0].DistanceTo(Points[1]);
        return side * side;
    }
}

class Rectangle : Fourangle
{
    public Rectangle(Point[] points) : base(points) { }

    public override double Area()
    {
        double width = Points[0].DistanceTo(Points[1]);
        double height = Points[0].DistanceTo(Points[3]);
        return width * height;
    }
}

class Trapezium : Fourangle
{
    public Trapezium(Point[] points) : base(points) { }

    public override double Area()
    {
        double height = Points[0].DistanceTo(Points[3]);
        double base1 = Points[0].DistanceTo(Points[1]);
        double base2 = Points[2].DistanceTo(Points[3]);
        return (base1 + base2) * height / 2;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Fourangle[] squares = new Fourangle[3];
        squares[0] = new Square(new Point[] { new Point(new double[] { 0, 0 }), new Point(new double[] { 1, 0 }), new Point(new double[] { 1, 1 }), new Point(new double[] { 0, 1 }) });
        squares[1] = new Square(new Point[] { new Point(new double[] { 2, 2 }), new Point(new double[] { 3, 2 }), new Point(new double[] { 3, 3 }), new Point(new double[] { 2, 3 }) });
        squares[2] = new Square(new Point[] { new Point(new double[] { 4, 4 }), new Point(new double[] { 5, 4 }), new Point(new double[] { 5, 5 }), new Point(new double[] { 4, 5 }) });

        Console.WriteLine("Квадрат:");
        Console.WriteLine("Имя === Периметр === Площадь");
        foreach (var square in squares.OrderByDescending(s => s.Area()))
        {
            Console.WriteLine($"{square}");
        }

        Fourangle[] rectangles = new Fourangle[3];
        rectangles[0] = new Rectangle(new Point[] { new Point(new double[] { 0, 0 }), new Point(new double[] { 2, 0 }), new Point(new double[] { 2, 1 }), new Point(new double[] { 0, 1 }) });
        rectangles[1] = new Rectangle(new Point[] { new Point(new double[] { 3, 2 }), new Point(new double[] { 4, 2 }), new Point(new double[] { 4, 3 }), new Point(new double[] { 3, 3 }) });
        rectangles[2] = new Rectangle(new Point[] { new Point(new double[] { 5, 4 }), new Point(new double[] { 6, 4 }), new Point(new double[] { 6, 5 }), new Point(new double[] { 5, 5 }) });

        Console.WriteLine("\nПрямоугольники:");
        Console.WriteLine("Имя === Периметр === Площадь");
        foreach (var rectangle in rectangles.OrderByDescending(r => r.Area()))
        {
            Console.WriteLine($"{rectangle}");
        }

        Fourangle[] trapeziums = new Fourangle[3];
        trapeziums[0] = new Trapezium(new Point[] { new Point(new double[] { 0, 0 }), new Point(new double[] { 2, 0 }), new Point(new double[] { 3, 1 }), new Point(new double[] { 1, 1 }) });
        trapeziums[1] = new Trapezium(new Point[] { new Point(new double[] { 4, 2 }), new Point(new double[] { 5, 2 }), new Point(new double[] { 6, 3 }), new Point(new double[] { 5, 3 }) });
        trapeziums[2] = new Trapezium(new Point[] { new Point(new double[] { 7, 4 }), new Point(new double[] { 8, 4 }), new Point(new double[] { 9, 5 }), new Point(new double[] { 7, 5 }) });

        Console.WriteLine("\nТрапеции:");
        Console.WriteLine("Имя === Периметр === Площадь");
        foreach (var trapezium in trapeziums.OrderByDescending(t => t.Area()))
        {
            Console.WriteLine($"{trapezium}");
        }

        // Combine the arrays and sort
        Fourangle[] figures = squares.Concat(rectangles).Concat(trapeziums).ToArray();
        Array.Sort(figures, (f1, f2) => f2.Area().CompareTo(f1.Area()));

        Console.WriteLine("\nВсе фигурочки:");
        Console.WriteLine("Имя === Периметр === Площадь");
        foreach (var figure in figures)
        {
            Console.WriteLine($"{figure}");
        }
    }
}