using System;

class JoroTheFootballPlayer
{
    static void Main()
    {
        byte yearWeekends = 52;
        string testYear = "f";
        string currentYear = Console.ReadLine();                      //  t / f
        int numberOfHolidays = int.Parse(Console.ReadLine());        //  p
        int weeksSpendInHometown = int.Parse(Console.ReadLine());   //  h
        int totalPlays = 0;
        int normalWeeks = yearWeekends - weeksSpendInHometown;
        normalWeeks = normalWeeks * 2 / 3;
        numberOfHolidays = numberOfHolidays / 2;


        if (currentYear == testYear)
        {
            totalPlays = normalWeeks + numberOfHolidays + weeksSpendInHometown;
            Console.WriteLine(totalPlays);
        }
        else
        {
            totalPlays = normalWeeks + numberOfHolidays + weeksSpendInHometown + 3;
            Console.WriteLine(totalPlays);

        }

    }
}
