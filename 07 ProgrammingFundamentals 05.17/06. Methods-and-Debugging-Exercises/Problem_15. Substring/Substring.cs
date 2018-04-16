using System;
using System.Collections.Generic;

public class Substring
{
    public static void Main()
    {
        string text = Console.ReadLine();
        int jump = int.Parse(Console.ReadLine());

        const char characterToSearch = 'p';
        bool hasMatch = false;

        List<string> matches = new List<string>();

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == characterToSearch)
            {
                hasMatch = true;

                int length = jump + 1;

                if (length + i > text.Length)
                {
                    length = text.Length - i;
                }
                else
                {
                    length = jump + 1;
                }

                string matchedString = text.Substring(i, length);
                i += jump;
                Console.WriteLine(matchedString);

                matches.Add(matchedString);
            }
        }

        if (!hasMatch)
        {
            Console.WriteLine("no");
        }
    }
}
