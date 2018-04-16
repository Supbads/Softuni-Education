using System;

class TheBiggestOf3Numbers
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double biggestNumber = 0;
        if (a > b)
        {
            biggestNumber = a;
        }
        else
        {
            biggestNumber = b;
        }
        if (biggestNumber > c)
        {
            Console.WriteLine(biggestNumber);
        }
        else
        {
            biggestNumber = c;
            Console.WriteLine(biggestNumber);
        }
    }
}
