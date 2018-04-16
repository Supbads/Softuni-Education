namespace Problem_3.Combinations_Iteratively
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            int k = 2;
            //int[] arr = new int[k];

            GenerateCombinations(n, k);

        }

        static void GenerateCombinations(int n, int k)
        {
            int[] combinations = new int[k];
            for (int i = 0; i < k; i++)
            {
                combinations[i] = i;
            }

            while (combinations[k - 1] < n)
            {
                Print(combinations);

                int t = k - 1;
                while (t != 0 && combinations[t] == n - k + t)
                {
                    t--;
                }

                combinations[t]++;
                for (int i = t + 1; i < k; i++)
                {
                    combinations[i] = combinations[i - 1] + 1;
                }
            }
        }
        private static void Swap(ref int i, ref int j)
        {
            if (i == j)
            {
                return;
            }

            i ^= j;
            j ^= i;
            i ^= j;
        }

        private static void Print(int[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
