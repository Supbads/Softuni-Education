using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_3.Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<char> uniqueSymbols = new HashSet<char>();

            string pattern = @"([\D]+)([\d]+)";

            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();

            var matches = regex.Matches(input);

            StringBuilder sb = new StringBuilder();

            foreach (Match match in matches)
            {
                var matchValue = match.Groups[1].ToString().ToUpper();
                var repeat = int.Parse(match.Groups[2].ToString());

                for (int i = 0; i < repeat; i++)
                {
                    sb.Append(matchValue); //.ToUpper()
                }
            }

            var rage = sb.ToString();
            
            foreach (var currentChar in rage)
            {
                uniqueSymbols.Add(currentChar);
            }


            Console.WriteLine("Unique symbols used: {0}",uniqueSymbols.Count);
            Console.WriteLine(rage);
        }
    }
}
