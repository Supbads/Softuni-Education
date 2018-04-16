using System;

class PointInaCircleAndOutsideaRectangle
{
    static void Main()
    {
        double XAxis = double.Parse(Console.ReadLine());
        double YAxis = double.Parse(Console.ReadLine());
        bool insideTheCircle = false;
        bool insideTheRectangle = false;
        double length = Math.Sqrt(XAxis * XAxis + YAxis * YAxis);
        if (XAxis < -1 || XAxis > 5 || YAxis < -1 || YAxis > 1)
        {
            insideTheRectangle = true;
        }

        insideTheCircle = (XAxis - 1) * (XAxis - 1) + (YAxis - 1) * (YAxis - 1) <= (1.5 * 1.5);

        if (insideTheCircle && insideTheRectangle)
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}
