using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Write the radius of your circle:");
        double radius = double.Parse(Console.ReadLine());
        double perimter = radius * 2 * Math.PI;
        double area = radius * radius * Math.PI;
        Console.WriteLine("The perimeter of your circle is: {0:F2}\n The area of your circle is: {1:F2}", perimter, area);
    }
}