using System;

class BackIn30Minutes
{
    static void Main()
    {
        int hours = int.Parse(Console.ReadLine());
        int minutes = int.Parse(Console.ReadLine());

        int minutesPlusThirty = minutes + 30;

        if (minutesPlusThirty > 60)
        {
            hours++;
            minutesPlusThirty %= 60;
        }
        if (hours >= 24)
        {
            hours = 0;
        }

        string paddedMinutes = minutesPlusThirty.ToString().PadLeft(2, '0');

        Console.WriteLine($"{hours}:{paddedMinutes}");
    }
}