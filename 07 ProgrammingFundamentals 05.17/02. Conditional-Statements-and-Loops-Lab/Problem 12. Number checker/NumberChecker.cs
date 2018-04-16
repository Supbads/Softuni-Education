using System;

class NumberChecker
{
    static void Main()
    {
        string numberToTryParse = Console.ReadLine();

        int outNumber;

        bool numberIsParsable = int.TryParse(numberToTryParse, out outNumber);


        if (numberIsParsable)
        {
            Console.WriteLine("It is a number.");
        }
        else
        {
            Console.WriteLine("Invalid input!");
        }
    }
}