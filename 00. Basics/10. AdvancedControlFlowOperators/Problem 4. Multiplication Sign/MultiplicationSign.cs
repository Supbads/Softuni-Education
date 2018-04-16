using System;

class MultiplicationSign
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        int i = 0;

        if (a < 0)
        {
            i++;
        }
        if (b < 0)
        {
            i++;
        }
        if (c < 0)
        {
            i++;
        }
        if (i % 2 == 0)
        {
            Console.WriteLine("+");
        }
        else
        {
            Console.WriteLine("-");
        }
    }
}
