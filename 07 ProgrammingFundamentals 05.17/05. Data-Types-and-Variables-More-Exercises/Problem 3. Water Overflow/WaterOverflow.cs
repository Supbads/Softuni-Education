using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Water_Overflow
{
    class WaterOverflow
    {
        static void Main(string[] args)
        {
            short totalLiters = 255;
            short literContainer = 0;

            int numberOfLine = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLine; i++)
            {
                short currentAmount = short.Parse(Console.ReadLine());

                if (currentAmount + literContainer > totalLiters)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }

                literContainer += currentAmount;
            }

            Console.WriteLine(literContainer);
        }
    }
}