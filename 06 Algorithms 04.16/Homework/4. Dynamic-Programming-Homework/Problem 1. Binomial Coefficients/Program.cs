namespace Problem_1.Binomial_Coefficients
{
    using System;

    class Program
    {
        private static int n;

        private static int k;

        private static int[,] binomTable;

        static void Main()
        {
            Console.WriteLine("enter \"n\"");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("enter \"k\"");
            k = int.Parse(Console.ReadLine());
            binomTable = new int[n + 1, k + 1];

            var coefficient = GetBinomCoef(n, k);
            Console.WriteLine(coefficient);
        }

        private static int GetBinomCoef(int n, int k)
        {
            if (k > n)
            {
                return 0;
            }

            if (0 == k || k == n)
            {
                return 1;
            }

            if (binomTable[n, k] != 0)
            {
                return binomTable[n, k];
            }
            
            binomTable[n, k] = GetBinomCoef(n - 1, k) + GetBinomCoef(n - 1, k - 1);

            return binomTable[n, k];
        }
    }
}
