using System;

class ThirdDigitIsSeven
{
    static void Main()
    {
        int i = int.Parse(Console.ReadLine());
        int reduceDigits = i / 100;
        if (reduceDigits % 10 == 7)
        {
            Console.WriteLine(true);
        }
        else
        {
            Console.WriteLine(false);
        }
    }
}
