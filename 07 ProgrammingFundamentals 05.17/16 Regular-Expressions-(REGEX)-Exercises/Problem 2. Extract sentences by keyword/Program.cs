using System;
using System.Text.RegularExpressions;

namespace Problem_2.Extract_sentences_by_keyword
{
    class Program
    {
        static void Main(string[] args)
        {
            string searchWord = Console.ReadLine();

            string text = Console.ReadLine();

            string pattern = string.Format(@"\b([^.?!]+\b{0}\b.*?)[?!.]", searchWord);

            Regex regex = new Regex(pattern);

            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[1]);
            }
        }
    }
}
