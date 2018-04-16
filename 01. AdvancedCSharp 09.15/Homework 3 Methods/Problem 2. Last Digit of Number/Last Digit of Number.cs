using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LastDigitOfNumber
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        if(number<0)
        {
            number *= -1;
        }

        int lastDigit = FindLastDigit(number);
        string digitAsWord = DigitAsWord(lastDigit);

        Console.WriteLine(digitAsWord);
    }
    private static int FindLastDigit(int num)
    {
        return num%10;
    }
    private static string DigitAsWord(int num)
    {
        switch (num)
        {
            case 0:
                return "Zero";
            case 1:
                return "One";
            case 2:
                return "Two";
            case 3:
                return "Three";
            case 4:
                return "Four";
            case 5:
                return "Five";
            case 6:
                return "Six";
            case 7:
                return "Seven";
            case 8:
                return "Eight";
            case 9:
                return "Nine";
            default:
                return "dunno";
        }
        return "dunno";
    }
}