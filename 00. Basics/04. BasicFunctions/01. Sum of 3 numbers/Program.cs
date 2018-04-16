using System;

class Program
{
    static void Main()
    {
        decimal firstNumber  = decimal.Parse(Console.ReadLine());
        decimal secondNumber = decimal.Parse(Console.ReadLine());
        decimal thirdNumber  = decimal.Parse(Console.ReadLine());
        Console.WriteLine("The sum of the three numbers is: " + (firstNumber+secondNumber+thirdNumber));

    }
}