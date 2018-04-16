using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ReverseNumber
{
    static void Main(string[] args)
    {
        double reversed = GetReversedNumber(Console.ReadLine());
        Console.WriteLine(reversed);
    }
    private static double GetReversedNumber(string input)
    {
        char[] charArray = input.ToCharArray();
        if (charArray[0] == '-')
        {
            charArray[0] = ' ';
            Array.Reverse(charArray);
            string str = "-" + new string(charArray);
            return double.Parse(str);
        }
        else
        {
            Array.Reverse(charArray);
            return double.Parse(new string(charArray));
        }
    }
}