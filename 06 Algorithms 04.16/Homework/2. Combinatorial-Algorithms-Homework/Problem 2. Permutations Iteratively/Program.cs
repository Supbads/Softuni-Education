namespace Problem_1.Permutations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static int[] a;

        private static int[] p;

        private static int n;

        private static int permutationsCount;

        static void Main()
        {
            n = Int32.Parse(Console.ReadLine());
            a = Enumerable.Range(1, n).ToArray();
            p = new int[n + 1];

            //GeneratePermutations(); //gives me the wrong results
            GeneratePerm();


            Console.WriteLine("Total permutations: " + permutationsCount);
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

        static void GeneratePermutations()
        {
            int i;
            int j;

            i = 1;
            while (i < n)
            {
                if (p[i] < i)
                {
                    j = i % 2 * p[i];

                    Swap(ref a[i], ref a[j]);

                    permutationsCount++;
                    Print(a);

                    p[i]++;
                    i = 1;
                }
                else
                {
                    p[i] = 0;
                    i++;
                }
            }
        }

        public static void GeneratePerm()
        {
            var p = Enumerable.Range(0, a.Length).ToArray();

            Print(p);
            permutationsCount++;

            var weights = new int[a.Length];
            var idxUpper = 1;
            while (idxUpper < a.Length)
            {
                if (weights[idxUpper] < idxUpper)
                {
                    var idxLower = idxUpper % 2 * weights[idxUpper];
                    Swap(ref p[idxLower], ref p[idxUpper]);
                    Print(p);
                    permutationsCount++;
                    weights[idxUpper]++;
                    idxUpper = 1;
                }
                else
                {
                    weights[idxUpper] = 0;
                    idxUpper++;
                }
            }
        }
    }
}