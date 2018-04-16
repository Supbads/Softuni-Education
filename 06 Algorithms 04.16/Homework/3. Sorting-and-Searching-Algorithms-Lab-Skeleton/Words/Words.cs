namespace Words
{
    using System;
    using System.Collections.Generic;

    public class Words
    {
        private static int permutationsCount = 0;

        public static void Main(string[] args)
        {
            char[] word = Console.ReadLine().ToCharArray();
            GeneratePermutations(word, 0);
            Console.WriteLine(permutationsCount);
        }

        private static void GeneratePermutations(char[] characters, int index)
        {
            if (index >= characters.Length)
            {
                if (!CheckForRepetitions(characters))
                {
                    permutationsCount++;
                }
                return;
            }

            HashSet<char> swapped = new HashSet<char>();
            for (int i = index; i < characters.Length; i++)
            {
                if (!swapped.Contains(characters[i]))
                {
                    Swap(ref characters[index], ref characters[i]);
                    GeneratePermutations(characters, index + 1);
                    Swap(ref characters[index], ref characters[i]);
                    swapped.Add(characters[i]);
                }
            }
        }

        private static bool CheckForRepetitions(char[] characters)
        {
            for (int ch = 1; ch < characters.Length; ch++)
            {
                if (characters[ch - 1] == characters[ch])
                {
                    return true;
                }
            }

            return false;
        }

        private static void Swap(ref char first, ref char second)
        {
            char temp = first;
            first = second;
            second = temp;
        }
    }
}
