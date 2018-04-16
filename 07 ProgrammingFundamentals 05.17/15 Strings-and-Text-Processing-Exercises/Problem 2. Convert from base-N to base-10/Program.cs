using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Problem_2.Convert_from_base_N_to_base_10
{
    class Program
    {
        static void Main(string[] args)
        {
            int baseN = new int();
                  
            var inputNumbers = Console.ReadLine().Split();

            char[] numberToConvert = inputNumbers[1].ToCharArray();
            Array.Reverse(numberToConvert);

            baseN = int.Parse(inputNumbers[0]);
            
            BigInteger convertedNumber = 0;
            
            for (int i = 0; i < numberToConvert.Length; i++)
            {
                var digit = new BigInteger(char.GetNumericValue(numberToConvert[i]));
                convertedNumber += digit * BigInteger.Pow(new BigInteger(baseN), i);
            }


            Console.WriteLine(convertedNumber);
        }
    }
}
