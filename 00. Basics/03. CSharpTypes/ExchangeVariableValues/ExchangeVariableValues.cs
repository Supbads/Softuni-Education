using System;

class ExchangeVariableValues
{
    static void Main()
    {
        int firstInt  = 8;
        int secondInt = 3;
        int holdsNumber;
        holdsNumber = firstInt;
        firstInt = secondInt;
        secondInt = holdsNumber;
        Console.WriteLine(firstInt + "\n" + secondInt);
    }
}

