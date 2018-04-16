using System;

class SumOfOddNumbers
{
    static void Main()
    {
        int numberOfOddNumbersToDisplay = int.Parse(Console.ReadLine());

        int topBorder = 2 * numberOfOddNumbersToDisplay;

        int sumOfOddNumbers = 0;

        for (int i = 1; i < topBorder; i+=2)
        {
            Console.WriteLine(i);
            sumOfOddNumbers += i;
        }

        Console.WriteLine("Sum: " + sumOfOddNumbers);

    }
}