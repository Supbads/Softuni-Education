using System;

namespace Problem_4.Nilapdromes
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            while (input != "end")
            {
                var length = input.Length;

                string nilapdrome = ValidatePalindrome(input, length);

                if (nilapdrome.Length > 0)
                {
                    Console.WriteLine(nilapdrome);
                }

                input = Console.ReadLine();
            }
        }

        private static string ValidatePalindrome(string input, int length)
        {
            string palindrome = string.Empty;

            var firstBorder = input.Substring(0, length / 2);
            var secondBorder = "";
            string border = "";

            if (input.Length % 2 == 0)
            {
                secondBorder = input.Substring(firstBorder.Length, input.Length - firstBorder.Length);
            }
            else // offset with one in case of odd length
            {
                secondBorder = input.Substring(firstBorder.Length + 1, input.Length - firstBorder.Length - 1);
            }

            while (true)
            {
                if (firstBorder == secondBorder)
                {
                    border = firstBorder;
                    break;
                }

                if (firstBorder != secondBorder)
                {
                    firstBorder = firstBorder.Substring(0, firstBorder.Length - 1); //remove one symbol from right
                    secondBorder = secondBorder.Substring(1, secondBorder.Length - 1);
                }

                if (firstBorder.Length == 0)// no need to check the second one as they are equivalent
                {
                    break;
                } 
            }

            if (border.Length != 0)
            {
                var core = input.Remove(input.Length - border.Length, border.Length);
                core = core.Substring(border.Length, core.Length - border.Length);

                if (core.Length != 0)
                {
                    palindrome = string.Format("{0}{1}{0}", core, border);
                }
            }

            return palindrome;
        }
    }
}