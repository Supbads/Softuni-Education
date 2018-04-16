using System;

namespace Problem_12.Master_Numbers
{
    class MasterNumbers
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            for (long i = 0; i <= n; i++)
            {
                bool atleastOneEvenDigit = IsAtleastOneDigitEven(i);

                if (!atleastOneEvenDigit)
                {
                    continue;
                }

                bool isSumDivisbleBySeven = IsSumDivisibleBySeven(i);
                if (!isSumDivisbleBySeven)
                {
                    continue;
                    
                }

                bool isPalindrome = IsPalindrome(i.ToString());
                if (isPalindrome)
                {
                    Console.WriteLine(i);
                }

            }



        }

        private static bool IsAtleastOneDigitEven(long n)
        {
            while (n > 0)
            {
                long currentDigit = n % 10;
                if (currentDigit % 2 == 0)
                {
                    return true;
                }

                n /= 10;
            }
            
            return false;
        }


        static bool IsPalindrome(string n)
        {
            char[] numReversed = n.ToCharArray();

            Array.Reverse(numReversed);

            for (int i = 0; i < n.Length; i++)
            {
                if (numReversed[i] != n[i])
                {
                    return false;
                }
            }

            return true;


            //int digits = n.Length;

            //if (digits == 1 || digits % 2 == 0)
            //{
            //    return false;
            //}

            //for (int i = 0; i < digits / 2; i++)
            //{
            //    if (n[i] != n[digits - i - 1])
            //    {
            //        return false;
            //    }
            //}

            //return true;

        }
        
        static bool IsSumDivisibleBySeven(long n)
        {
            long sum = 0;

            while (n != 0)
            {
                sum += n % 10;
                n /= 10;
            }

            if (sum % 7 == 0)
            {
                return true;
            }

            return false;

        }
    }
}