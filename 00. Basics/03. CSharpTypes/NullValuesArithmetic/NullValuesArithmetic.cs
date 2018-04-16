using System;

class Program
{
    static void Main()
    {
        int? intVariable = null;
        double? doubleVariable = null;

        Console.WriteLine(intVariable + " " + doubleVariable);
        intVariable += 4;
        Console.WriteLine(intVariable);
        doubleVariable += null;
        Console.WriteLine(doubleVariable);
    }
}

