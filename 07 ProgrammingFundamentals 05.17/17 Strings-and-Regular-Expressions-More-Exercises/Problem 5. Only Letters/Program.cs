using System;
using System.Text.RegularExpressions;

namespace Problem_5.Only_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"([0-9]+)([a-zA-Z])";
            Regex regex = new Regex(pattern);

            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                string digits = match.Groups[1].ToString();
                string letter = match.Groups[2].ToString();

                Regex replacer = new Regex(Regex.Escape(digits));

                input = replacer.Replace(input, letter, 1);
            }

            Console.WriteLine(input);

        }
    }
}