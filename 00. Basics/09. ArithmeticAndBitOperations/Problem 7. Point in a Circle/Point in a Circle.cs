using System;

class PointInACircle
{
    static void Main()
    {
        Console.WriteLine("Enter the coordinates of your point (X , Y)");
        float XAxis = float.Parse(Console.ReadLine());
        float YAxis = float.Parse(Console.ReadLine());
        double length = Math.Sqrt((XAxis * XAxis) + (YAxis * YAxis));
        if (length <= 2.0)
        {
            Console.WriteLine(true);
        }
        else
        {
            Console.WriteLine(false);
        }
    }
}
