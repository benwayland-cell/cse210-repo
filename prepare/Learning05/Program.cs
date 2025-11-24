using System;

class Program
{
    static void Main(string[] args)
    {
        Shape testShape = new Circle("color", 10);

        Console.WriteLine(testShape.GetColor());
        testShape.SetColor("other color");
        Console.WriteLine(testShape.GetColor());

        Console.WriteLine(testShape.GetArea());
    }
}