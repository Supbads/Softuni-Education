using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int num = int.Parse(Console.ReadLine());

        int indexOfLastOccurance = -1;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == num)
            {
                indexOfLastOccurance = i;
            }    
        }

        if (indexOfLastOccurance == -1)
        {
            Console.WriteLine("No occurrences were found!");
            return;
        }

        long sum = 0;

        for (int i = 0; i < indexOfLastOccurance; i++)
        {
            sum += arr[i];
        }

        Console.WriteLine(sum);

    }
}
