using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int difference = int.Parse(Console.ReadLine());

        int pairs = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[i] - numbers[j] == difference || numbers[j] - numbers[i] == difference)
                {
                    pairs++;
                }
            }
        }

        Console.WriteLine(pairs);
    }
}