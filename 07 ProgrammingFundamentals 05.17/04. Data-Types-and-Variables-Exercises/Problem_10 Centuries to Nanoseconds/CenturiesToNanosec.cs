using System;

namespace Problem_10_Centuries_to_Nanoseconds
{
    class CenturiesToNanosec
    {
        static void Main(string[] args)
        {
            int centuries = int.Parse(Console.ReadLine());
            int years = centuries * 100;
            int days = (int)Math.Floor(years * 365.242222);
            int hours = days * 24;
            long minutes = hours * 60;
            long seconds = minutes * 60;
            string miliseconds = seconds.ToString() + "000";
            string microseconds = miliseconds + "000";
            string nanoseconds = microseconds + "000";

            Console.WriteLine("{0} centuries = {1} years = {2} days = {3} hours = {4} minutes = {5} seconds = {6} milliseconds = {7} microseconds = {8} nanoseconds", centuries, years, days, hours, minutes, seconds, miliseconds, microseconds, nanoseconds);
        }
    }
}