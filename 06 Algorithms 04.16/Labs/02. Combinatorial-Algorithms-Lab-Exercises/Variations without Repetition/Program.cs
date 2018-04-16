namespace Variations_without_Repetition
{
    using System;

    class Program
    {
        private static int k;

        private static int n;

        private static bool[] used;


        static void Main(string[] args)
        {
            k = 2;
            n = 3;

            int[] array = new int[k];
            used = new bool[n + 1];

            GenerateVariation(array);
        }

        static void GenerateVariation(int[] arr, int index = 0)
        {
            if (index >= arr.Length)
            {
                Print(arr);
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    arr[index] = i;
                    GenerateVariation(arr, index + 1);
                    used[i] = false;
                }
            }
        }

        private static void Print(int[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));

        }
    }
}
