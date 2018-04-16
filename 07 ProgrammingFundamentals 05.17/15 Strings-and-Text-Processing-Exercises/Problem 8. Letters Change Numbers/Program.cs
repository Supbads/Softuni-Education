using System;
using System.Linq;

class LettersChangeNumbers
{
    static void Main()
    {
        // input
        var line = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        // logic
        double result = 0;
        foreach (var str in line)
        {
            // parse alphanumeric string
            var firstLetter = str.First();
            var lastLetter = str.Last();
            var number = double.Parse(str.Substring(1, str.Length - 2));

            number = ApplyFirstLetterCalculations(firstLetter, number);

            number = ApplySecondLetterCalculations(lastLetter, number);

            result += number;
        }

        // print
        Console.WriteLine("{0:F2}", result);
    }

    private static double ApplySecondLetterCalculations(char lastLetter, double number)
    {
        if (char.IsUpper(lastLetter))
        {
            number -= lastLetter - 'A' + 1;
        }
        else if (char.IsLower(lastLetter))
        {
            number += lastLetter - 'a' + 1;
        }
        return number;
    }

    private static double ApplyFirstLetterCalculations(char firstLetter, double number)
    {
        if (char.IsUpper(firstLetter))
        {
            number /= firstLetter - 'A' + 1;
        }
        else if (char.IsLower(firstLetter))
        {
            number *= firstLetter - 'a' + 1;
        }
        return number;
    }
}