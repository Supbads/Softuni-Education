using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Stateless
{
    class Program
    {
        static void Main(string[] args)
        {
            const int fictionEndTrimAmount = 1;

            string input = Console.ReadLine();
           

            while (input != "collapse")
            {
                string fiction = Console.ReadLine();

                
                var fictionSubstring = fiction.Substring(0, fiction.Length);

                while (fictionSubstring.Length > 0)
                {
                    

                    var occuranceIndex = input.IndexOf(fictionSubstring);
                    while (occuranceIndex != -1)
                    {
                        input = input.Remove(occuranceIndex, fictionSubstring.Length);
                        occuranceIndex = input.IndexOf(fictionSubstring);
                    }

                    var symbolsToTake = Math.Max(fictionSubstring.Length - (2 * fictionEndTrimAmount), 0); // assures the symbolsTakeCount is not negative
                    fictionSubstring = fictionSubstring.Substring(fictionEndTrimAmount, symbolsToTake);
                }

                if (input == "")
                {
                    Console.WriteLine("(void)");
                }
                else
                {
                    Console.WriteLine(input.Trim());
                }

                input = Console.ReadLine();
            }

        }
    }
}
