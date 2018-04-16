using System;

class GravitationOnTheMoon
{
    static void Main()
    {
        Console.WriteLine("Enter your current weight");
        decimal weight = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Your weight will be {0} on the moon.",weight*17/100);

    }
}
