using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Palindromes
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
        List<string> palindromes = new List<string>();
        for (int i = 0; i < input.Length; i++)
        {
            if (IsPalindrome(input[i]))
            {
                palindromes.Add(input[i]);
            }
        }
        palindromes.Sort();
        Console.WriteLine(string.Join(", ", palindromes));
    }

    static bool IsPalindrome(string str)
    {
        int min = 0;
        int max = str.Length - 1;
        while (true)
        {
            if (min > max)
            {
                return true;
            }
            char char1 = str[min];
            char char2 = str[max];

            if (!char1.Equals(char2))
            {
                return false;
            }
            min++;
            max--;
        }
    }
}