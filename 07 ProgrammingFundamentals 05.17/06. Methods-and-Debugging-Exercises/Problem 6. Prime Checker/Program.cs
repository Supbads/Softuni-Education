using System;

namespace Problem_6.Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            long numberToCheck = long.Parse(Console.ReadLine());
            
            bool isPrime = CheckIfNumberIsPrime(numberToCheck);


            char[] upperCaseLetter = isPrime.ToString().ToCharArray();
            upperCaseLetter[0] = char.ToUpper(upperCaseLetter[0]);

            Console.WriteLine(new string(upperCaseLetter));
        }

        private static bool CheckIfNumberIsPrime(long numberToCheck)
        {
            if (numberToCheck == 0 || numberToCheck == 1)
            {
                return false;
            }

            if (numberToCheck == 2)
            {
                return true;
            }

            bool isPrime = true;

            for (long i = 2; i < Math.Sqrt(numberToCheck) + 1; i++)
            {
                if (numberToCheck % i == 0)
                {
                    isPrime = false;
                }
            }

            return isPrime;

        }
    }
}