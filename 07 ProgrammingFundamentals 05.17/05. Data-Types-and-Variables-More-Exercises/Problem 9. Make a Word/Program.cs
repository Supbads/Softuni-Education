using System;
using System.Linq;

namespace Problem_9.Make_a_Word
{
    class Program
    {
        static void Main(string[] args)
        {
            short n = short.Parse(Console.ReadLine());

            char[] word = new char[n];

            for (int i = 0; i < n; i++)
            {
                word[i] = Console.ReadLine().FirstOrDefault();
            }

            Console.Write("The word is: ");

            foreach (var letter in word)
            {
                Console.Write(letter);
            }

        }
    }
}