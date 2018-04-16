using System;

namespace Problem_15.Fast_Prime_Checker
{
    class FastPrimeChecker
    {
        static void Main(string[] args)
        {
            int numbersToCheck = int.Parse(Console.ReadLine());

            for (int currentNumber = 2; currentNumber <= numbersToCheck; currentNumber++)
            {
                bool isPrime = true;

                double highestIndexNumber = Math.Sqrt(currentNumber);
                for (int currentDivider = 2; currentDivider <= highestIndexNumber; currentDivider++)
                {
                    if (currentNumber % currentDivider == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{currentNumber} -> {isPrime}");

            }
        }
    }
}