using System;

class PrimeNumberCheck
{
    static void Main()
    {
        short number = short.Parse(Console.ReadLine());
        bool isPrime = true;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                isPrime = false;
                break;
            }

        }
        Console.WriteLine(isPrime);
    }
}
