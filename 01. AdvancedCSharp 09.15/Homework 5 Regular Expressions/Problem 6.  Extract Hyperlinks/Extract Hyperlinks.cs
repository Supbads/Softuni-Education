using System;
using System.Text;
using System.Text.RegularExpressions;

class ExtractHyperlinks
{
    static void Main(string[] args)
    {
        //<a href="http://softuni.bg" class="new"></a>
        //< p > This text has no links</ p >
        //END

        string inputLine;
        StringBuilder sb = new StringBuilder();
        while (!((inputLine = Console.ReadLine()) == "END"))
        {
            sb.Append(inputLine);
        }
        string text = sb.ToString();
        string pattern = @"<a\s+(?:[^>]+\s+)?href\s*=\s*(?:'(?<url>[^']*)'|""(?<url>[^""]*)""|(?<url>[^\s>]+))[^>]*>";
        Regex users = new Regex(pattern);
        MatchCollection matches = users.Matches(text);
        //Console.WriteLine("Found {0} matches", matches.Count);
        foreach (Match hyperlink in matches)
        {
            Console.WriteLine(hyperlink.Groups["url"]);
        }
    }
}

