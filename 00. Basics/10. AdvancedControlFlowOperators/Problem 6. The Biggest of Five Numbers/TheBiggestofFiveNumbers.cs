using System;

class TheBiggestofFiveNumbers
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double d = double.Parse(Console.ReadLine());
        double e = double.Parse(Console.ReadLine());

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

        }
        else
        {
            biggestNumber = c;
        }

        if (biggestNumber < d)
        {
            biggestNumber = d;
        }
        else
        {

        }

        if (biggestNumber < e)
        {
            biggestNumber = e;
            Console.WriteLine(biggestNumber);
        }
        else
        {
            Console.WriteLine(biggestNumber);
        }

    }
}