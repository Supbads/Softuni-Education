using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_7.Primes_in_Given_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            int low = int.Parse(Console.ReadLine());
            int high = int.Parse(Console.ReadLine());

            List<int> primesList = new List<int>();
            

            for (int primeCandidate = low; primeCandidate <= high; primeCandidate++)
            {
                if (CheckIfNumberIsPrime(primeCandidate))
                {
                    primesList.Add(primeCandidate);
                }
            }

            int lastElement = primesList.Last();

            for (int i = 0; i < primesList.Count - 1; i++)
            {
                Console.Write(primesList[i] + ", ");
            }

            Console.WriteLine(lastElement);
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
