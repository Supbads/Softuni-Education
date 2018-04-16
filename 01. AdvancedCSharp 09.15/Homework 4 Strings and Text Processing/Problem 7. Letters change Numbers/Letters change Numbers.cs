using System;
using System.Linq;
using System.Text.RegularExpressions;

class LettersChangeNumbers
{
    static void Main(string[] args)
    {
        string[] input = Regex.Split(Console.ReadLine().Trim(), @"\s+");
        decimal total = 0;

        foreach (string str in input)
        {
            decimal number = Convert.ToDecimal(str.Substring(1, str.Length - 2));

            if (Char.IsLower(str.First()))
            {
                number *= (decimal)(str.First() - 'a' + 1);
            }
            else
            {
                number /= (decimal)(str.First() - 'A' + 1);
            }

            if (Char.IsLower(str.Last()))
            {
                number += (decimal)(str.Last() - 'a' + 1);
            }
            else
            {
                number -= (decimal)(str.Last() - 'A' + 1);
            }

            total += number;
        }
    }
}