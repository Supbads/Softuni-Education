using System;
using System.Text.RegularExpressions;

class ReplaceATag
{
    static void Main(string[] args)
    {
        //string input = "<ul><li><a href=http://softuni.bg>SoftUni</a></li></ul>";

        string input = Console.ReadLine();
        string pattern = @"<a(.*?)>(.*?)<\/a>";
        string url = "[URL$1]$2[/URL]";
        Regex regex = new Regex(pattern);
        Console.WriteLine(regex.Replace(input, url));

    }
}
