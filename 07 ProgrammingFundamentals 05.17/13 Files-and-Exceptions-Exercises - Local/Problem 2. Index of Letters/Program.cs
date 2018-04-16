using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Index_of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputDirecotry = @"../../input.txt";
            string outputDirecotry = @"../../output.txt";

            Dictionary<char, int> alphabet = new Dictionary<char, int>();

            FillAlphabetIndexes(alphabet);

            var inputChars = File.ReadAllText(inputDirecotry);

            StringBuilder sb =  new StringBuilder();
            var list = new List<string>();
            foreach (var inputChar in inputChars)
            {
                list.Add(string.Format("{0} -> {1}",inputChar, alphabet[inputChar]));
                //sb.AppendLine(string.Format("{0} -> {1}", inputChar, alphabet[inputChar]));
            }

            //File.WriteAllText(outputDirecotry,sb.ToString());

            File.WriteAllLines(outputDirecotry, list);


        }

        private static void FillAlphabetIndexes(Dictionary<char, int> alphabet)
        {
            for (int i = 'a'; i < 'z'; i++)
            {
                
                alphabet.Add((char)i, i - 'a');
            }
        }
    }
}