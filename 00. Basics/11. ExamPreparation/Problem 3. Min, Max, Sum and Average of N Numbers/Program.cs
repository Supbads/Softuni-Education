using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        uint n = uint.Parse(Console.ReadLine());

        List<int> numbers = new List<int>((int)n);

        for (int i = 0; i < n; i++)
        {
            numbers.Add(int.Parse(Console.ReadLine()));
        }

        int numMin = int.MaxValue;
        int numMax = int.MinValue;
        int sumOfAllNumbers = 0;

        foreach (var number in numbers)
        {
            numMin = Math.Min(numMin, number);
            numMax = Math.Max(numMax, number);
            sumOfAllNumbers += number;
        }
        double averageNumbers = sumOfAllNumbers / (double)n;

        Console.WriteLine("min = {0} \nmax = {1}", numMin, numMax);
        Console.WriteLine("sum = {0} \naverage = {1:F2}", sumOfAllNumbers, averageNumbers);

    }
}
