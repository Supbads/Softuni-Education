using System;
using System.Linq;

class SumOfChars
{
    static void Main(string[] args)
    {
        short n = short.Parse(Console.ReadLine());

        char[] word = new char[n];

        for (int i = 0; i < n; i++)
        {
            word[i] = Console.ReadLine().FirstOrDefault();
        }

        long sum = 0;

        foreach (var letter in word)
        {
            sum += letter;
        }

        Console.WriteLine("The sum equals: " + sum);

    }
}