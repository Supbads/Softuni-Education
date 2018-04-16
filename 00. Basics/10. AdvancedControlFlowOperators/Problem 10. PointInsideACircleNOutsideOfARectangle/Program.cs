using System;

class PointInsideACircleNOutsideOfARectangle
{
    static void Main()
    {
        Console.WriteLine("X coordinate:");
        decimal coordinateX = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Y coordinate:");
        decimal coordinateY = decimal.Parse(Console.ReadLine());
        decimal radius = 1.5m;

        bool isInCircle = (coordinateX - 1) * (coordinateX - 1) + (coordinateY - 1) * (coordinateY - 1) <= radius * radius;
        if (isInCircle && coordinateY > 1)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}
