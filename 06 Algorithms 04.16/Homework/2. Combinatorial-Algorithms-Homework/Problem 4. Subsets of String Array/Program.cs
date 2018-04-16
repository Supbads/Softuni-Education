namespace Problem_4.Subsets_of_String_Array
{
    using System;
    using System.Linq;

    class Program
    {
        private static int k;

        private static int n;

        private static string[] set;

        static void Main(string[] args)
        {
            set = new[] { "test", "rock", "fun"};
            k = 2;
            n = set.Length - 1;
            int[] arr = new int[k];

            GenerateSubsets(arr, 0, 0);

        }

        static void GenerateSubsets(int[] array, int index, int startValue)
        {
            if (index >= k)
            {
                Print(array);
                return;
            }

            for (int i = startValue; i <= n; i++)
            {
                array[index] = i;
                GenerateSubsets(array, index + 1, i + 1); // add +1 to i to make it without repetition
            }
        }

        private static void Print(int[] arr)
        {
            //Map arr values to indices of set
            Console.WriteLine(string.Join(", ", arr.Select(i => set[i])));
        }
    }
}
