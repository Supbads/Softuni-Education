using System;

class Sort3NumbersWithNestedIfs
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double biggest  = 0;
        double middle   = 0;
        double smallest = 0;

        if (a > b && a > c)
        {
            biggest = a;
            if (b > c)
            {
                middle = b;
                smallest = c;
            }
            else
            {
                middle = c;
                smallest = b;
            }
        }

        else if (b > a && b > c)
        {
            biggest = b;
            if (a > c)
            {
                middle = a;
                smallest = c;
            }
            else
            {
                middle = c;
                smallest = a;
            }
        }

        else if (c > a && c > b)
        {
            biggest = c;

            if (a > b)
            {
                middle = a;
                smallest = b;
            }
            else
            {
                middle = b;
                smallest = a;
            }

        }
        Console.WriteLine("{0} {1} {2}", biggest,middle,smallest);
    }
}
