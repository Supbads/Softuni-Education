using System;

namespace Problem_5.Fibonacci_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int fibNumberToCheck = int.Parse(Console.ReadLine());

            int nthFibNumber = Fib(fibNumberToCheck);

            Console.WriteLine(nthFibNumber);

        }

        private static int Fib(int fibNumber)
        {
            if (fibNumber == 1 || fibNumber == 0)
            {
                return 1;
            }

            return Fib(fibNumber - 1) + Fib(fibNumber - 2);
        }
    }
}
