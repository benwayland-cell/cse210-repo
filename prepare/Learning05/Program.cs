using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> testShapes = new List<Shape> {
            new Square("square color", 10),
            new Rectangle("rectangle color", 10, 20),
            new Circle("circle color", 10)
        };

        foreach (Shape shape in testShapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}");
            Console.WriteLine($"Area: {shape.GetArea()}\n");
        }
    }
}