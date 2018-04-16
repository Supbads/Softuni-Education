using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_1.Extract_emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\s([a-z0-9]+[\w._-]*[a-z0-9]+@[^.][\w-]+\.[\w.]+)\b";

            Regex regex = new Regex(pattern);

            string text = Console.ReadLine();
            
            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[1]);

            }

            //@"\s?([a-z0-9]+[\w._-]*[a-z0-9]+@[^.][\w-]+\.[\w.]+)\b";

            //var words = text.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);

            //@"\s?([a-z0-9]+[\w._-]*[a-z0-9]+@[^.][\w-]+\.[\w.]+)\b";

            //foreach (var word in words)
            //{
            //    var match = regex.Match(word);

            //    if (match.Success)
            //    {
            //        Console.WriteLine(word);
            //    }
            //}

        }
    }
}
