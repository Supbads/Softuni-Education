using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_4.Punctuation_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[.,,!?:]";

            Regex regex = new Regex(pattern);

            string inputDirectory = "../../sample_text.txt";
            string outputDirectory = "../../output_text.txt";

            var text = File.ReadAllText(inputDirectory);

            List<string> matchesList = new List<string>();

            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                matchesList.Add(match.Value);
            }

            File.WriteAllText(outputDirectory, string.Join(", ", matchesList));
        }
    }
}
