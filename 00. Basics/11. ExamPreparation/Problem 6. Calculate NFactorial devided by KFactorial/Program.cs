using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        int factorialN = 1;
        int factorialK = 1;

        if (k < n)
        {
            for (int i = 1; i<=n ; i++)
            {
                factorialN *= i;
                if (i<=k)
                {
                    factorialK *= i;
                }
            }
        }
        else
        {
            Console.WriteLine("invalid input.");
        }
        Console.WriteLine(factorialN/factorialK);
    }
}
