using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Charity_Marathon
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            long runners = long.Parse(Console.ReadLine());
            int averageNumberOfLaps = int.Parse(Console.ReadLine());
            long trackLength = int.Parse(Console.ReadLine());
            int trackCapaciy = int.Parse(Console.ReadLine());
            double moneyPerKilometer = double.Parse(Console.ReadLine());

            long totalCapacity = days * trackCapaciy;
            var runCount = Math.Min(runners, totalCapacity);

            var totalMeters = averageNumberOfLaps * runCount * trackLength;

            double totalKilometers = totalMeters / 1000.0;

            Console.WriteLine("Money raised: {0:F2}",totalKilometers*moneyPerKilometer);
        }
    }
}
