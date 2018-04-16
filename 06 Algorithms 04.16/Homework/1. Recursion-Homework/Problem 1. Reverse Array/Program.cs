namespace Problem_1.Reverse_Array
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            ReverseArray(arr, 0, arr.Length - 1);
            arr.ToList().ForEach(Console.Write);
            Console.WriteLine();
        }
        
        private static void ReverseArray(int[] array, int index, int top)
        {
            if (index >= top)
            {
                return;
            }
            
            var element = array[index];
            array[index] = array[top];
            array[top] = element;
            ReverseArray(array, index + 1, top - 1);
        }

        //private static void ReverseArray(int[] array, int index)
        //{
        //    if (index == array.Length - (array.Length / 2))
        //    {
        //        array[array.Length - index] = array[index];
        //    }
        //    else
        //    {
        //        var element = array[index];

        //    }
        //}
    }
}
