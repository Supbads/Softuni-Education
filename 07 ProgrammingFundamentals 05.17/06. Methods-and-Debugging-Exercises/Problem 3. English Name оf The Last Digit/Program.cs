using System;
using System.Linq;

namespace Problem_3.English_Name_оf_The_Last_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string lastDigitName = NameOfLastDigit(input);
            Console.WriteLine(lastDigitName);
        }

        private static string NameOfLastDigit(string input)
        {
            char lastDigit = input.LastOrDefault();

            if (lastDigit == '0')
            {
                return "zero";
            }
            if (lastDigit == '1')
            {
                return "one";
            }
            if (lastDigit == '2')
            {
                return "two";
            }
            if (lastDigit == '3')
            {
                return "three";
            }
            if (lastDigit == '4')
            {
                return "four";
            }
            if (lastDigit == '5')
            {
                return "five";
            }
            if (lastDigit == '6')
            {
                return "six";
            }
            if (lastDigit == '7')
            {
                return "seven";
            }
            if (lastDigit == '8')
            {
                return "eight";
            }
            if (lastDigit == '9')
            {
                return "nine";
            }

            return null;
        }
    }
}