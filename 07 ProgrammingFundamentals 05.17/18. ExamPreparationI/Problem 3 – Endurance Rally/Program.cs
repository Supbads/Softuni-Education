using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3___Endurance_Rally
{
    class Program
    {
        static void Main()
        {
            //Console.WriteLine((int)'C');

            var racers = Console.ReadLine().Split().ToList();

            var track = Console.ReadLine().Split().Select(double.Parse).ToArray();

            var checkpoints = Console.ReadLine().Split().Select(long.Parse).ToList();


            foreach (var racer in racers)
            {
                double fuel;

                var passed = RunTrack(track, checkpoints, out fuel, racer[0]);


                if (passed)
                {
                    Console.WriteLine(racer + " - fuel left {0:F2}", fuel);
                    
                }
                else
                {
                    Console.WriteLine("{0} - reached {1}",racer,fuel);
                }
            }

        }

        private static bool RunTrack(double[] track, List<long> checkpoints, out double fuel, double startingFuel)
        {
            fuel = startingFuel;

            for (int i = 0; i < track.Length; i++)
            {
                if (checkpoints.Contains(i))
                {
                    fuel += track[i];
                }
                else
                {
                    fuel -= track[i];
                    if (fuel <= 0)
                    {
                        fuel = i;
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
