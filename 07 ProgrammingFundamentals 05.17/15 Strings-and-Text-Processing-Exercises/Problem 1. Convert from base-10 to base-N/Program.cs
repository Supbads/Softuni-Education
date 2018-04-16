using System;
using System.Collections.Generic;
using System.Numerics;

namespace Problem_1.Convert_from_base_10_to_base_N
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> reminders = new Stack<int>();
            BigInteger decNumber = new BigInteger();
            BigInteger baseN = new BigInteger();

            var inputNumbers = Console.ReadLine().Split();

            baseN = BigInteger.Parse(inputNumbers[0]);
            decNumber = BigInteger.Parse(inputNumbers[1]);


            while (decNumber>0)
            {
                var remainder = (int)(decNumber % baseN);

                reminders.Push(remainder);
                decNumber /= baseN;
            }

            string convertedNumber = string.Empty;

            while (reminders.Count > 0)
            {
                var currentElement = reminders.Pop();
                convertedNumber += currentElement;
            }

            Console.WriteLine(convertedNumber);

        }
    }
}
