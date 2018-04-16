using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_5.Magic_exchangeable_words
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, char> respectiveLetters = new Dictionary<char, char>();

            var input = Console.ReadLine().Split();

            //order apperently is important since you're matching from the first array to the second and not both simultaniously
            //eg. o -> a  != a -> o
            var longerString = input[0];
            var shorterString = input[1];
            
            if (shorterString.Length > longerString.Length)
            {
                var temp = shorterString;
                shorterString = longerString;
                longerString = temp;
            }


            bool areExchangeable = true;


            //mapping longer -> shorter
            for (int i = 0; i < longerString.Length; i++)
            {
                if (i >= shorterString.Length)
                {
                    var currentChar = longerString[i];

                    //check if there are no new letters or letters are respective
                    if (!respectiveLetters.ContainsKey(currentChar))
                    {
                        areExchangeable = false;
                        break;
                    }

                    continue;
                }

                var firstChar = longerString[i];
                var secondChar = shorterString[i];

                //foo bar
                // o -> a
                // a -> o
                // r -> o

                if (!respectiveLetters.ContainsKey(firstChar) && !respectiveLetters.ContainsValue(firstChar))
                {
                    respectiveLetters.Add(firstChar, secondChar);
                }
                else
                {
                    if (respectiveLetters[firstChar] != secondChar)
                    {
                        areExchangeable = false;
                        break;
                    }
                }
                

            }

            Console.WriteLine(areExchangeable.ToString().ToLower());

        }
    }
}
