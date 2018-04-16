using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int bomb = tokens[0];
        int power = tokens[1];

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] != bomb)
            {
                continue;
            }

            numbers[i] = 0;

            int leftIndex = i - 1;
            int rightIndex = i + 1;

            while (leftIndex >= 0 && leftIndex >= i - power)
            {
                numbers[leftIndex] = 0;
                leftIndex--;
            }

            while (rightIndex < numbers.Length && rightIndex <= power + i)
            {
                numbers[rightIndex] = 0;
                rightIndex++;
            }


        }
        //Console.WriteLine(string.Join(" ", numbers));

        long sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        Console.WriteLine(sum);
    }
}