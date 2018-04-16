namespace Problem_3.Combinations_with_Repetition
{
    using System;

    class Program
    {
        private static int n;

        private static int k;

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());

            int[] numbers = new int[k];
            CombinationsWithRepetition(numbers, 0, 1);

        }

        static void CombinationsWithRepetition(int[] array, int index, int startValue)
        {
            if (index >= k)
            {
                Console.WriteLine(string.Join(" ", array));
                return;
            }

            for (int i = startValue; i <= n; i++)
            {
                array[index] = i;
                CombinationsWithRepetition(array, index + 1, i + 1); // add +1 to i to make it with repetition
            }
        }
    }
}
