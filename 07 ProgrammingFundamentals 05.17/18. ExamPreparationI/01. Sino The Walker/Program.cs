using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Sino_The_Walker
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split(new [] {':'}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int inputHours = tokens[0];
            long inputMinutes = inputHours * 60 + tokens[1];
            long inputSeconds = inputMinutes * 60 + tokens[2];

            long steps = long.Parse(Console.ReadLine());
            long timePerStep = long.Parse(Console.ReadLine());
            
            //shenanighans
            long totalSecondsTime = timePerStep * steps;
            totalSecondsTime += inputSeconds;

            long hours;
            long minutes;
            long secods;

            minutes = totalSecondsTime / 60;
            secods = totalSecondsTime % 60;

            hours = minutes / 60;
            minutes %= 60;

            hours %= 24;

            string hoursStr = PadLefLong(hours);
            string minutesStr = PadLefLong(minutes);
            string secondsStr = PadLefLong(secods);

            Console.WriteLine("Time Arrival: {0}:{1}:{2}",hoursStr,minutesStr,secondsStr );







            TimeSpan time = TimeSpan.Parse(Console.ReadLine()); // 15:08:14
            int step = int.Parse(Console.ReadLine()) % 86400; //451948947
            int seconds = int.Parse(Console.ReadLine()) % 86400; //4578489
            long sumStep = step * seconds;
            TimeSpan asdf = TimeSpan.FromSeconds(sumStep);
            TimeSpan timeSum = time + asdf;
            Console.WriteLine("Time Arrival: {0:hh\\:mm\\:ss}", timeSum);
        }

        static string PadLefLong(long num)
        {
            string str = string.Empty;

            str = num.ToString().PadLeft(2, '0');

            return str;
        }

    }
}
