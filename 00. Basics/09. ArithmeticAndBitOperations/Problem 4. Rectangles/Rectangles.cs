using System;

class Rectangles
{
    static void Main()
    {
        Console.WriteLine("Enter the width of your rectangle.");
        double width = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the height of your rectangle.");
        double height = double.Parse(Console.ReadLine());
        double perimeter = 2.0 * width + 2.0 * height;
        double area = width*height;
        Console.WriteLine("The perimeter of your rectangle is: {0} \nThe area of your rectangle is: {1}",perimeter,area);


    }
}
