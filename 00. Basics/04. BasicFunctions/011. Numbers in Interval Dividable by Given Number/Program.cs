using System;

class Program
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = 0;

        for (int i = a; i <= b; i++)
        {
            if ((i % 5) == 0)
            {
                c++;
            }
        }

        Console.WriteLine(c);

    }
}