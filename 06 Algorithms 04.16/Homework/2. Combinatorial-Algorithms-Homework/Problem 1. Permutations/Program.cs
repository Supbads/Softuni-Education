namespace Problem_1.Permutations
{
    using System;
    using System.Linq;

    class Program
    {
        private static int permutationsCount;

        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());
            var array = Enumerable.Range(1, n).ToArray();
            GeneratePermutations(array, 0);
            Console.WriteLine("Total permutations: " + permutationsCount);
        }

        static void GeneratePermutations(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                Print(arr);
                permutationsCount++;
                return;
            }

            for (int i = index; i < arr.Length; i++)
            {
                Swap(ref arr[i], ref arr[index]);
                GeneratePermutations(arr, index + 1);
                Swap(ref arr[i], ref arr[index]);
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
