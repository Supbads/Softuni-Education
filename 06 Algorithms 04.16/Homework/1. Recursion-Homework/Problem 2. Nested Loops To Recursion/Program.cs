namespace Problem_2.Nested_Loops_To_Recursion
{
    using System;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var array = new int[n];
            NthRecursiveLoops(array, n, 0);
        }

        private static void NthRecursiveLoops(int[] array, int n, int index)
        {
            if (array.Length == index)
            {
                Console.WriteLine(string.Join(" ", array));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                array[index] = i;
                NthRecursiveLoops(array, n, index + 1);
            }
        }
    }
}
