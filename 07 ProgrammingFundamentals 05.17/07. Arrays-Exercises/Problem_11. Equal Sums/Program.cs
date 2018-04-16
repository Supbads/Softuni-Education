using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int arrLength = numbers.Length;

        for (int i = 0; i < arrLength; i++)
        {
            int leftSum = 0;
            int rightSum = 0;

            int leftIndex = i - 1;
            int rightIndex = i + 1;

            while(leftIndex >= 0)
            {
                leftSum += numbers[leftIndex];
                leftIndex--;
            }

            while (rightIndex < arrLength)
            {
                rightSum += numbers[rightIndex];

                rightIndex++;
            }

            if (leftSum == rightSum)
            {
                Console.WriteLine(i);
                return;
            }
        }
        
        Console.WriteLine("no");
    }
}