using System;
using System.Collections.Generic;

class TheatrePromotions
{
    static int[,] pricesPerDay = new int[,]
    {
      //0-18 18-64 64-122
        { 12,  18,  12 },  //Weekday
        { 15,  20,  15 },  //Weekend
        { 5,   12,  10 }   //Holiday

    };

    private static string[] dates = {"Weekday", "Weekend", "Holiday"};

    static List<string> dayType = new List<string>(dates);

    static void Main()
    {
        string currentDay = Console.ReadLine();
        int ageOfPerson = int.Parse(Console.ReadLine());

        if (ageOfPerson < 0 || ageOfPerson > 122)
        {
            Console.WriteLine("Error!");
            return;
        }

        int dayIndex = dayType.IndexOf(currentDay);

        int ageIndex = -1;

        if (ageOfPerson >= 0 && ageOfPerson <= 18)
        {
            ageIndex = 0;
        }
        else if (ageOfPerson >= 19 && ageOfPerson <= 64)
        {
            ageIndex = 1;
        }
        else
        {
            ageIndex = 2;
        }

        Console.WriteLine($"{pricesPerDay[dayIndex, ageIndex]}$");

    }
}