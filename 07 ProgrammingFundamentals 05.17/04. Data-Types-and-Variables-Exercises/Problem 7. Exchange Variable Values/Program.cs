using System;

namespace Problem_7.Exchange_Variable_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            Console.WriteLine("Before:\na = {0}\nb = {1}", firstNum, secondNum);

            IntegerSwap(ref firstNum, ref secondNum);

            Console.WriteLine("After:\na = {0}\nb = {1}", firstNum, secondNum);
        }

        static void IntegerSwap(ref int a, ref int b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }
    }
}