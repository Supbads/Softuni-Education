using System;

class OddOrEvenIntegers
{
    static void Main()
    {
        Console.WriteLine("Enter an integer number.");
        int n;
        string parseAtempt = Console.ReadLine();
        bool number = int.TryParse(parseAtempt, out n);
        if (n % 2 == 0)
        {
            Console.WriteLine("Your number is even");
        }
        else
        {
            Console.WriteLine("Your number is odd");
        }

    }
}
