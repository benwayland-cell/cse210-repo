using System;

using static Months;

enum Months {January, February, March, April, May, June, July, August, September, October, November, December}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Sandbox World!");

        int[] nums = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30];

        Console.WriteLine($"The numers of days in December is: {nums[(int)December]}");
    }
}