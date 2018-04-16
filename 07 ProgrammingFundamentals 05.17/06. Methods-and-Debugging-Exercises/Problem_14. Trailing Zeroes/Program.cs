using System;
using System.Numerics;

namespace Problem_14.Trailing_Zeroes
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            BigInteger factorial = CalculateFactorial(number);

            Console.WriteLine(FindTrailingZeros(factorial));

        }

        static int FindTrailingZeros(BigInteger n)
        {
            int zeroCounter = 0;
            while (n % 5 == 0)
            {
                n /= 5;
                zeroCounter += 1;
            }

            return zeroCounter;
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
