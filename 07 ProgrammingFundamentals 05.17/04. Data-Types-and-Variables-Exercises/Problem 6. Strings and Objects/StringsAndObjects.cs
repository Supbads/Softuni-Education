using System;

namespace Problem_6.Strings_and_Objects
{
    class StringsAndObjects
    {
        static void Main(string[] args)
        {
            string firstLine = Console.ReadLine();
            string secondLine = Console.ReadLine();

            object obj = new object();
            obj = firstLine + " " + secondLine;

            string objectToString = (string)obj;

            Console.WriteLine(objectToString);
            
        }
    }
}