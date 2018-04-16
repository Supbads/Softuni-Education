using System;
using System.Numerics;

namespace Problem_13.Factorial
{
    class Factorial
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(CalculateFactorial(number));

        }

        public static BigInteger CalculateFactorial(int n)
        {
            BigInteger sum = n;
            BigInteger result = n;
            for (int i = n - 2; i > 1; i -= 2)
            {
                sum = (sum + i);
                result *= sum;
            }

            if (n % 2 != 0)
            {
                result *= n / 2 + 1;
            }

            return result;
        }
    }
}