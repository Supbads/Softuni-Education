using System;
using System.Linq;
using System.Text.RegularExpressions;

class SeriesOfLetters
{
    static void Main(string[] args)
    {
        string pattern = @"([a-zA-Z])\1+";
        //string text = "aaaaabbbbbcdddeeeedssaa";
        string text = Console.ReadLine();
        
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(text);
        foreach (Match match in matches)
        {
            string tempPattern = match.ToString();
            string replace = tempPattern.First().ToString();
            Regex tempRegex = new Regex(tempPattern);
            text = tempRegex.Replace(text, replace);
        }
        Console.WriteLine(text);
    }
}
