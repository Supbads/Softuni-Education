using System;

class Program
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        long a = 0;
        long b = 1;
        long c;
        if (n == 1)
        {
            Console.WriteLine(a);
        }
        else if (n == 2)
        {
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
        else if (n < 0)
        {
            Console.WriteLine("Enter a number from 0 to +inf. !");
        }
        else if (n > 2)
        {
            Console.WriteLine(a);
            Console.WriteLine(b);
            for (long i = 3; i <= n; i++)
            {
                c = b + a;
                a = b;
                b = c;
                Console.WriteLine(c);
            }
        }
    }
}