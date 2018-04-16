using System;

class MonthPrinter
{
    static void Main()
    {
        string[] months = new[]
        {
            null, "January", "February", "March", "April", "May", "June", "July", "August", "September", "October",
            "November", "December"
        };

        int monthNumer = int.Parse(Console.ReadLine());

        if (monthNumer < 1 || monthNumer > 12)
        {
            Console.WriteLine("Error!");
            return;
        }

        Console.WriteLine(months[monthNumer]);

    }
}