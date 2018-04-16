using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_13.Vowel_or_Digit
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //a, e, i, o, u.
            HashSet<char> vowels = new HashSet<char>(new []{'a', 'e', 'i', 'o', 'u'});
            HashSet<char> digits = new HashSet<char>(new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });

            char input = Console.ReadLine().FirstOrDefault();

            if (vowels.Contains(input))
            {
                Console.WriteLine("vowel");
            }
            else if (digits.Contains(input))
            {
                Console.WriteLine("digit");
            }
            else
            {
                Console.WriteLine("other");
            }


        }
    }
}