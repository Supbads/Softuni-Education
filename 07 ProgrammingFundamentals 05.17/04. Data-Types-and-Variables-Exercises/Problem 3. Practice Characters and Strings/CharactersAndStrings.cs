using System;
using System.Linq;

namespace Problem_3.Practice_Characters_and_Strings
{
    class CharactersAndStrings
    {
        static void Main()
        {
            string firstInput = Console.ReadLine();
            char secondInput = Console.ReadLine().FirstOrDefault();
            char thirdInput = Console.ReadLine().FirstOrDefault();
            char fourthInput = Console.ReadLine().FirstOrDefault();
            string fifthInput = Console.ReadLine();

            Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n",firstInput,secondInput,thirdInput,fourthInput,fifthInput);
            
        }
    }
}