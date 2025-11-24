using System;

class Program
{
    static void Main(string[] args)
    {
        Shape testShape = new Rectangle("color", 10, 20);

        Console.WriteLine(testShape.GetColor());
        testShape.SetColor("other color");
        Console.WriteLine(testShape.GetColor());

        Console.WriteLine(testShape.GetArea());
    }
}