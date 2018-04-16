using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_11.Convert_Speed_Units
{
    class Program
    {
        static void Main(string[] args)
        {
            //Assume 1 mile = 1609 meters.
            float distanceInMeters = float.Parse(Console.ReadLine());
            float hours = float.Parse(Console.ReadLine());
            float minutes = float.Parse(Console.ReadLine());
            float seconds = float.Parse(Console.ReadLine());

            float totalSeconds = hours * 60 * 60 + minutes * 60 + seconds;
            float metersPerSecond = distanceInMeters / totalSeconds;

            Console.WriteLine(metersPerSecond);
            //WriteStringFormatToSixthSymbol(metersPerSecond);

            float kilometers = distanceInMeters / 1000;
            float kilometersPerHour = kilometers / (totalSeconds/3600);

            Console.WriteLine(kilometersPerHour);
            //WriteStringFormatToSixthSymbol(kilometersPerHour);

            float miles = distanceInMeters / 1609;
            float milesPerHour = miles / (totalSeconds / 3600);

            Console.WriteLine(milesPerHour);
            //WriteStringFormatToSixthSymbol(milesPerHour);


        }

        private static void WriteStringFormatToSixthSymbol(double metersPerSecond)
        {
            Console.WriteLine("{0:0.00000#}", metersPerSecond);
        }
    }
}