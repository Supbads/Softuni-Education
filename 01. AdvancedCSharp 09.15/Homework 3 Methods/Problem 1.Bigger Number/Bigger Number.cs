using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BiggerNumber
{
    static void Main(string[] args)
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());

        int bigger = FindBigger(firstNumber, secondNumber);
        Console.WriteLine(bigger);
    }

    static int FindBigger(int a, int b)
    {
        if(a>b)
        {
            return a;
        }
        else
        {
            return b;
       }
    }
}