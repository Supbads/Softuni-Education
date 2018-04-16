using System;
using System.Linq;

namespace Problem_7.Hideout
{
    class Program
    {
        static void Main(string[] args)//using regex here is stupid
        {
            //List<string> trashCharacters = new List<string>() { "[", "\\", "(", "+", "*", "?", "|", ".", "$", "^", "(", ")", "{", "#" };
            string input = Console.ReadLine();

            while (true)
            {
                var tokens = Console.ReadLine().Split();
                var hideoutSymbol = tokens[0].FirstOrDefault();
                var hideoutLenght = int.Parse(tokens[1]);
                
                string hideoutString = new string(hideoutSymbol, hideoutLenght);

                var indexOfOccurance = input.IndexOf(hideoutString);

                if (indexOfOccurance < 0)
                {
                    continue;
                }

                var length = 0;

                for (int i = indexOfOccurance; i < input.Length; i++)
                {
                    if (input[i] == hideoutSymbol)
                    {
                        length++;
                    }
                    else
                    {
                        break;
                    }
                }

                Console.WriteLine("Hideout found at index {0} and it is with size {1}!", indexOfOccurance, length);
                break;
                
                // Regex is scary
                //if (trashCharacters.Contains(hideoutSymbol))
                //{
                //    hideoutSymbol = @"\" + hideoutSymbol;
                //}
                ////string searchPattern = string.Format("{0}{\\{1\\},}", hideoutSymbol, hideoutLenght);
                //string searchPattern = hideoutSymbol + "{" + hideoutLenght + ",}";
                //Regex rgx = new Regex(searchPattern);

                //var match = rgx.Match(input);

                //if (!match.Success)
                //{
                //    continue;
                //}

                //var length = match.Value.Length;
                //var startIndex = input.IndexOf(hideoutString);

                //Console.WriteLine("Hideout found at index {0} and it is with size {1}!",startIndex,length);
                //break;
            }

        }
    }
}
