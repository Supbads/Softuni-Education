using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        string[] numbers = Console.ReadLine().Split();
        List<int> reversedNumbers = new List<int>();

        for (int i = 0; i < numbers.Length; i++)
        {
            var currentElement = numbers[i].ToCharArray();
            Array.Reverse(currentElement);

            int elementAsInt = int.Parse(new string(currentElement));

            reversedNumbers.Add(elementAsInt);
        }

        long sum = 0;
        for (int i = 0; i < reversedNumbers.Count; i++)
        {
            sum += reversedNumbers[i];
        }

        Console.WriteLine(sum);
    }
}