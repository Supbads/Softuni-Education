using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_5.Use_Your_Chains__Buddy
{
    class Program
    {
        static void Main()
        {
            string wholeText = Console.ReadLine();

            string pattern = @"<p>(.*?)<\/p>";

            Regex regex = new Regex(pattern);

            var matches = regex.Matches(wholeText);

            StringBuilder decryptedText = new StringBuilder();

            foreach (Match match in matches)
            {
                var matchedText = match.Groups[1].ToString();

                matchedText = Regex.Replace(matchedText, "[^a-zw0-9]+", " ");

                char[] decryptedMessage = new char[matchedText.Length];

                char a = 'a';
                char m = 'm';
                char n = 'n';
                char z = 'z';

                for (int i = 0; i < matchedText.Length; i++)
                {
                    char currentChar = matchedText[i];

                    if (currentChar < a || currentChar > z)
                    {
                        decryptedMessage[i] = currentChar;
                        continue;
                    }

                    if (currentChar >= 1 && currentChar <= m)
                    {
                        decryptedMessage[i] = ((char)(currentChar + (n - a + 1) - 1));
                    }
                    else
                    {
                        decryptedMessage[i] = ((char)(currentChar - (n - a + 1) + 1));
                    }

                }
                
                decryptedText.Append(new string (decryptedMessage));
            }

            string str = decryptedText.ToString();

            str = Regex.Replace(str, @"\s+", " ");

            Console.WriteLine(str);

            //– all letters from a to m are converted to letters from n to z (a  n; b  o; … m  z). 
            //). The letters from n to z are converted to letters from a to m (n  a; o  b; … z  m)


            //). All multiple spaces should then be replaced by only one space.



        }
    }
}
