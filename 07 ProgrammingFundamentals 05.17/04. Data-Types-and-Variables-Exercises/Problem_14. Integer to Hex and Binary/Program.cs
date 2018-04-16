using System;

namespace Problem_14.Integer_to_Hex_and_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNum = int.Parse(Console.ReadLine());

            Console.WriteLine(Convert.ToString(inputNum, 16).ToUpper());
            Console.WriteLine(Convert.ToString(inputNum, 2));

        }
    }
}