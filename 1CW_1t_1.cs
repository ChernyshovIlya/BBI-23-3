using System;

struct Point
{
    public double X { get; }
    public double Y { get; }

    public Point(double[] coordinates)
    {
        if (coordinates.Length != 2)
        {
            throw new ArgumentException("Надо 2 координаты хд");
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

class Program
{
    static void Main(string[] args)
    {
        Point[] points = new Point[3];
        points[0] = new Point(new double[] { 0, 0 });
        points[1] = new Point(new double[] { 3, 4 });
        points[2] = new Point(new double[] { 6, 8 });

        Console.WriteLine(" Пара === Расстояние между");
        for (int i = 0; i < points.Length; i++)
        {
            for (int j = i + 1; j < points.Length; j++)
            {
                Console.WriteLine($" {i + 1} и {j + 1} === {points[i].DistanceTo(points[j])}");
            }
        }
    }
}