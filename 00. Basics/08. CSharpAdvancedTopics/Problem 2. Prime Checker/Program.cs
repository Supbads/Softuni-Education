using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        bool primeCheck = IsPrime(n);
        Console.WriteLine(primeCheck);

    }
    static bool IsPrime(int n)
    {
        if (n<2)
        {
            return false;
        }

        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if ((n % i) == 0)
            {
                return false;
            }
        }
        return true;

    }
}
