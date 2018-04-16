using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        BigInteger top = 1;
        BigInteger bottom = 1;

        for (int i = 2 + n ; i <= n*2 ; i++ )
        {
            top *= i;
        }
        for (int i = 1; i <= n; i++)
        {
            bottom *= i;
        }
        Console.WriteLine(top/bottom);

    }
}
