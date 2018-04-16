using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        // Uvh34yt78y78y7Y&T^^DFt362t62thfwuihhYG&GY2 
        // Did you know Math.Round rounds to the nearest even integer?
        string input = Console.ReadLine();
        char[] sentance = input.ToCharArray(); Array.Sort(sentance);

        int counter = 0;

        for (int i = 0; i < sentance.Length - 1; i++)
        {
            counter++;
            if (sentance[i] != sentance[i + 1])
            {
                Console.WriteLine("{0}: {1} time/s", sentance[i], counter);
                counter = 0;
            }

            if (i == sentance.Length - 2)
            {
                Console.WriteLine("{0}: {1} time/s", sentance[i + 1], ++counter);
            }
        }
        Console.WriteLine();
        Console.WriteLine("With Dictionary: ");

        input = Console.ReadLine();
        sentance = input.ToCharArray();
        Dictionary<char, int> dictionary = new Dictionary<char, int>();
        foreach (var character in sentance)
        {
            if (dictionary.ContainsKey(character))
            {
                dictionary[character]++;
            }
            else
            {
                dictionary.Add(character, 1);
            }
            //var items = from pair in dictionary
            //            orderby pair.Value ascending
            //            select pair;
        }
        foreach(var character in dictionary.OrderBy(i => i.Key))
        {
            Console.WriteLine("{0}:{1}",character.Key,character.Value);
        }
    }
}
