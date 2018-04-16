using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        var arr = Console.ReadLine().Split();

        string pattern = string.Format(@"\|<.{{{0}}}([^\|<]{{0,{1}}})",arr[0],arr[1]);
        //string pattern = string.Format(@"\|<.{{{0}}}([^\|<]{{1,{1}}})",arr[0],arr[1]); // atleast 1 otherwise ""
        //string pattern = string.Format(@"\|<[^\|<]{{{0}}}([^\|<]{{0,{1}}})",arr[0],arr[1]); // firPartMustNotContain |<
        //string pattern = string.Format(@"\|<[^\|<]{{{0}}}([^\|<]{{1,{1}}})",arr[0],arr[1]); // firPartMustNotContain |< + atleast 1

        string input = Console.ReadLine();

        Regex regex = new Regex(pattern);

        List<string> captures = new List<string>();

        var matches = regex.Matches(input);
        foreach (Match match in matches)
        {
            captures.Add(match.Groups[1].ToString());
        }

        Console.WriteLine(string.Join(", ", captures));
    }
}