using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_4.Query_Mess
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            string pattern = @"([^&?]+)\s*=\s*([^&?]+)";
            //string pattern = "([^&?]+)\s*=\s*([^&?]+)"
            //[?& ]?([^&?]+)\s*=\s*([^&?]+)[?& ]?
            Regex regex = new Regex(pattern);

            while (input != "END")
            {
                Dictionary<string, List<string>> pairs = new Dictionary<string, List<string>>();

                input = Regex.Replace(input, @"(%20|\+)+", " ");

                var matches = regex.Matches(input);

                foreach (Match match in matches)
                {
                    var field = match.Groups[1].ToString().Trim();
                    var value = match.Groups[2].ToString().Trim();

                    if (!pairs.ContainsKey(field))
                    {
                        pairs.Add(field, new List<string>());
                    }

                    pairs[field].Add(value);
                }

                foreach (var pair in pairs)
                {
                    Console.Write("{0}=[{1}]",pair.Key, string.Join(", ", pair.Value));

                }
                Console.WriteLine();


                input = Console.ReadLine();
            }

        }
    }
}