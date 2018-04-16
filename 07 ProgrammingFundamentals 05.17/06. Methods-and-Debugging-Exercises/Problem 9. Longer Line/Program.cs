using System;

class Program
{
    static void Main(string[] args)
    {
        double ax1 = double.Parse(Console.ReadLine());
        double ay1 = double.Parse(Console.ReadLine());
        double ax2 = double.Parse(Console.ReadLine());
        double ay2 = double.Parse(Console.ReadLine());

        double bx1 = double.Parse(Console.ReadLine());
        double by1 = double.Parse(Console.ReadLine());
        double bx2 = double.Parse(Console.ReadLine());
        double by2 = double.Parse(Console.ReadLine());

        double firstLineLength = CalculateLengthOfLine(ax1, ay1, ax2, ay2);
        double secondLineLength = CalculateLengthOfLine(bx1, by1, bx2, by2);

        if (firstLineLength >= secondLineLength)
        {
            if (FindPointCloserToCenter(ax1, ay1, ax2, ay2))
            {
                Print(ax1, ay1, ax2, ay2);
            }
            else
            {
                Print(ax2, ay2, ax1, ay1);
            }
        }
        else
        {
            if (FindPointCloserToCenter(bx1, by1, bx2, by2))
            {
                Print(bx1, by1, bx2, by2);
            }
            else
            {
                Print(bx2, by2, bx1, by1);
            }
        }
    }

    private static void Print(double ax1, double ay1, double ax2, double ay2)
    {
        Console.WriteLine("({0}, {1})({2}, {3})", ax1, ay1, ax2, ay2);
    }

    private static double CalculateLengthOfLine(double x1, double y1, double x2, double y2)
    {
        double deltaX = x2 - x1;
        double deltaY = y2 - y1;

        return Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
    }

    private static bool FindPointCloserToCenter(double x1, double y1, double x2, double y2)
    {
        double lengthOfFirstPointFromCenter = Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));
        double lengthOfSecondPointFromCenter = Math.Sqrt(x2 * x2 + y2 * y2);

        if (lengthOfFirstPointFromCenter <= lengthOfSecondPointFromCenter)
        {
            return true;
        }

        return false;
    }
}