namespace Problem_5.Permutations_with_Repetition
{
    using System;
    using System.Linq;

    class Program
    {
        private static int n;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());

            var arr = Enumerable.Range(1, n).ToArray();
            Permutate(arr, 0, arr.Length - 1);
        }

        static void Permutate(int[] arr, int start, int end)
        {
            Print(arr);

            for (int left = end - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                {
                    if (arr[left] != arr[right])
                    {
                        Swap(ref arr[left], ref arr[right]);
                        Permutate(arr, left + 1, end);
                    }
                }

                var firstElement = arr[left];
                for (int i = left; i <= end - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[end] = firstElement;
            }
        }

        static void Print(int[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }

        static void Swap(ref int first, ref int second)
        {
            if (first == second)
            {
                return;
            }

            first ^= second;
            second ^= first;
            first ^= second;
        }
    }
}
