using System;
using System.Linq;

namespace Problem_9.Reverse_Characters
{
    class ReverseCharacters
    {
        static void Main(string[] args)
        {
            char firstChar = Console.ReadLine().FirstOrDefault();
            char secondChar = Console.ReadLine().FirstOrDefault();
            char thirdChar = Console.ReadLine().FirstOrDefault();

            Console.WriteLine("{0}{1}{2}", thirdChar,secondChar,firstChar);
        }
    }
}