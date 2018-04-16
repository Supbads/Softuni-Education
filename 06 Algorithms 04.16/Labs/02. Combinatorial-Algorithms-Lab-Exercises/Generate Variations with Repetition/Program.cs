namespace Generate_Variations_with_Repetition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());
            int k = Int32.Parse(Console.ReadLine());

            int[] arr = new int[k];
            GenerateVariation(arr, n);

        }

        private static void GenerateVariation(int[] arr, int sizeOfSet, int index = 0)
        {
            if (index >= arr.Length)
            {
                Print(arr);
            }
            else
            {
                for (int i = 1; i <= sizeOfSet; i++)
                {
                    arr[index] = i;
                    GenerateVariation(arr, sizeOfSet, index + 1);
                }
            }
        }

        private static void Print(int[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
