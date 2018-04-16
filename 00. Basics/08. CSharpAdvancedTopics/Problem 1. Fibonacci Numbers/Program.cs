using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int fibNumber = Fib(n);
        Console.WriteLine(fibNumber);

    }

    static int Fib(int n)
    {
        if(n <= 0)
        {
            return 0;
        }

        if(n == 1)
        {
            return 1;
        }
        int a = 1;
        int b = 2;
        int c;
        for (int i = 1; i < n-1; i++)
        {
            c = b;
            b += a;
            a = c;


        }
        return b;

    }
}
