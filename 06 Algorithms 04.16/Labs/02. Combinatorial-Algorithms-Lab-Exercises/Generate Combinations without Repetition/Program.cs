using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generate_Combinations_with_Repetition
{
    class Program
    {
        private static int k;

        private static int n;

        static void Main(string[] args)
        {
            k = 2;
            n = 3;
            int[] array = new int[k];
            GenerateCombination(array, 0);
        }

        private static void GenerateCombination(int[] arr, int index, int start = 1)
        {
            if (index >= arr.Length)
            {
                Print(arr);
                return;
            }

            for (int i = start; i <= n; i++)
            {
                arr[index] = i;
                GenerateCombination(arr, index + 1, i + 1);
            }

        }

        private static void Print(int[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
