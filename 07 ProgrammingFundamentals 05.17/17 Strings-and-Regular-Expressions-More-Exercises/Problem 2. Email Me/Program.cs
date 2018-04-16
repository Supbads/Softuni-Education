using System;

namespace Problem_2.Email_Me
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var args = input.Split('@');

            var leftSum = SumCharacters(args[0]);
            var rightSum = SumCharacters(args[1]);

            if (leftSum - rightSum >= 0)
            {
                Console.WriteLine("Call her!");
            }
            else
            {
                Console.WriteLine("She is not the one.");
            }
        }

        static long SumCharacters(string input)
        {
            long sum = 0;

            foreach (char currentChar in input)
            {
                sum += (int) currentChar;
            }


            return sum;
        }

    }
}
