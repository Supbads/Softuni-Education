using System;
using System.Globalization;

namespace _02.Date_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstDateStr = Console.ReadLine();
            var secondDateStr = Console.ReadLine();

            var firstDate = DateTime.ParseExact(firstDateStr, "yyyy MM dd", DateTimeFormatInfo.InvariantInfo);
            var secondDate = DateTime.ParseExact(secondDateStr, "yyyy MM dd", DateTimeFormatInfo.InvariantInfo);

            var dateModifier = new DateModifier(firstDate, secondDate);

            Console.WriteLine(dateModifier.Difference());
        }
    }
}