using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        string separator = Console.ReadLine();
        string evenOrOdd = Console.ReadLine();
        short n = short.Parse(Console.ReadLine());

        int offset = 0;

        if (evenOrOdd == "even")
        {
            offset = 1;
        } //else == 0

        List<string> words = new List<string>(n/2);

        for (int i = 0; i < n; i++)
        {
            string word = Console.ReadLine();

            if (i % 2 == offset)
            {
                words.Add(word); 
            }
        }

        string output = string.Join(separator, words);

        Console.WriteLine(output);
        
    }
}