using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Serialize_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, List<int>> charsAndIndexes = new Dictionary<char, List<int>>();

            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];

                if (!charsAndIndexes.ContainsKey(currentChar))
                {
                    charsAndIndexes.Add(currentChar, new List<int>());
                }

                charsAndIndexes[currentChar].Add(i);
            }

            foreach (var charAndIndexes in charsAndIndexes)
            {
                var currentChar = charAndIndexes.Key;
                var charIndexes = charAndIndexes.Value;

                Console.WriteLine("{0}:{1}",currentChar,string.Join(@"/",charIndexes));
            }


        }
    }
}