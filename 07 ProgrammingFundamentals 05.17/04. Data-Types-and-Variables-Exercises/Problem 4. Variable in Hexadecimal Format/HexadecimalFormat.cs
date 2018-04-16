using System;

namespace Problem_4.Variable_in_Hexadecimal_Format
{
    class HexadecimalFormat
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            Console.WriteLine($"{HexadecimalConverter(input)}");
        }

        static int HexadecimalConverter(string input)
        {
            return Convert.ToInt32(input, 16);
        }
    }
}
