using System;
using System.Collections.Generic;

namespace Problem_3.Pyramidic
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<char, int> charAndOccurances = new Dictionary<char, int>();
            int currentMax = -1;
            char maxChar = (char)1;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                HashSet<char> alreadyChecked = new HashSet<char>();
                foreach (var currentChar in input)
                {
                    if (alreadyChecked.Contains(currentChar))
                    {
                        continue;
                    }
                    
                    alreadyChecked.Add(currentChar);

                    if (!charAndOccurances.ContainsKey(currentChar))
                    {
                        charAndOccurances.Add(currentChar,0);
                    }

                    var searchCount = charAndOccurances[currentChar];

                    if (searchCount == 0)
                    {
                        searchCount = 1;
                    }
                    else
                    {
                        searchCount += 2;
                    }

                    if (input.Contains(new string(currentChar, searchCount)))
                    {
                        charAndOccurances[currentChar] = searchCount;

                        if (currentMax < searchCount)
                        {
                            currentMax = searchCount;
                            maxChar = currentChar;
                        }
                    }
                    else
                    {
                        charAndOccurances[currentChar] = 1;
                    }
                }

                var keysToUpdate = new List<char>(charAndOccurances.Keys);
                foreach (var currentChar in keysToUpdate)
                {
                    if (!alreadyChecked.Contains(currentChar))
                    {
                        charAndOccurances[currentChar] = 0;
                    }
                }
            }

            for (int i = 1; i <= currentMax; i+=2)
            {
                Console.WriteLine(new string(maxChar, i));
            }


        }
    }
}