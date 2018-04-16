using System;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string keyText = Console.ReadLine();

        string keyPattern = @"([a-zA-Z]+)[\|\\<].*[\|\\<]([a-zA-Z]+)"; // possibly .*?
        Regex keyRegex = new Regex(keyPattern);

        string startKey = string.Empty;
        string endKey = string.Empty;

        var keysMatch = keyRegex.Match(keyText);

        startKey = keysMatch.Groups[1].ToString();
        endKey = keysMatch.Groups[2].ToString();

        string text = Console.ReadLine();

        string textMatcher = string.Format("{0}(.*?){1}", startKey, endKey);
        Regex textRegex = new Regex(textMatcher);

        var matches = textRegex.Matches(text);

        StringBuilder result = new StringBuilder();

        foreach (Match match in matches)
        {
            result.Append(match.Groups[1]);
        }


        string concatenatedResult = result.ToString();

        if (concatenatedResult.Length > 0)
        {
            Console.WriteLine(concatenatedResult);
        }
        else
        {
            Console.WriteLine("Empty result");   
        }
    }
}