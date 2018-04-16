using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int min = numbers.Min();
        int max = numbers.Max();

        long sum = numbers.Sum();

        double average = sum / (double)numbers.Length;

        Console.WriteLine("Min = " + min);
        Console.WriteLine("Max = " + max);
        Console.WriteLine("Sum = " + sum);
        Console.WriteLine("Average = {0}", average);

    }
}
