using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Problem_3.Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var usernames = Console.ReadLine().Split(new[] {' ', '/', '\\', '(', ')'},
                StringSplitOptions.RemoveEmptyEntries);

            string pattern = @"^[a-zA-Z][a-zA-Z0-9_]{2,24}$";
            //string pattern = @"\b[a-zA-Z]\w{2,24}\b";

            Regex regex = new Regex(pattern);

            var validatedUsernames = new List<string>();

            foreach (var username in usernames)
            {
                if (regex.IsMatch(username))
                {
                    validatedUsernames.Add(username);
                }
            }

            //lengeth
            int bestLengthIndex = 1;
            int bestLength = -1;

            for (int i = 1; i < validatedUsernames.Count; i++)
            {
                int currentLengthSum = validatedUsernames[i].Length + validatedUsernames[i - 1].Length;
                if (currentLengthSum > bestLength)
                {
                    bestLength = currentLengthSum;
                    bestLengthIndex = i;
                }
            }

            Console.WriteLine(validatedUsernames[bestLengthIndex - 1]);
            Console.WriteLine(validatedUsernames[bestLengthIndex]);

        }
    }
}
