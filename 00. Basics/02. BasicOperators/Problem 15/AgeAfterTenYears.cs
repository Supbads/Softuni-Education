using System;

class AgeAfterTenYears
{
    static void Main()
    {
        Console.WriteLine("Please enter your date of birth(year,month,day).");
        DateTime bday = DateTime.Parse(Console.ReadLine());
        DateTime today = DateTime.Today;
        int age = today.Year - bday.Year;
        Console.WriteLine("You are {0} years old and you will be {1} years old after ten years.", age, age + 10);
    }
}