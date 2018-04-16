using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_9.Melrah_Shake
{
    class Program
    {
        private static string successfulShake = "Shaked it.";
        private static string unsuccessfulShake = "No shake.";

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = Console.ReadLine();

            //Regex regex = new Regex(pattern);

            int firstMatchIndex = input.IndexOf(pattern);
            int lastMatchIndex = input.LastIndexOf(pattern);

            //var matches = regex.Matches(input);

            while (pattern.Length > 0 && firstMatchIndex != lastMatchIndex && pattern.Length < input.Length)
            {
                Console.WriteLine(successfulShake);

                input = input.Remove(lastMatchIndex, pattern.Length); //-1 ?
                input = input.Remove(firstMatchIndex, pattern.Length);

                pattern = pattern.Remove(pattern.Length / 2, 1);

                firstMatchIndex = input.IndexOf(pattern);
                lastMatchIndex = input.LastIndexOf(pattern);

            }

            Console.WriteLine(unsuccessfulShake);
            Console.WriteLine(input);

        }
    }
}
