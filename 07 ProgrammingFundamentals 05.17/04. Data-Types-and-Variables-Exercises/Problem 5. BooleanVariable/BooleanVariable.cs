using System;

namespace Problem_5.BooleanVariable
{
    class BooleanVariable
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            bool stringToBool= Convert.ToBoolean(input);

            Console.WriteLine(stringToBool ? "Yes" : "No");
        }
    }
}