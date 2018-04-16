using System;

namespace Problem_4.Numbers_in_Reversed_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            Array.Reverse(input);

            Console.WriteLine(new string(input));
        }
    }
}
