using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_14.Boat_Simulator
{
    class BoatSimulator
    {
        static void Main(string[] args)
        {
            char firstBoat = Console.ReadLine().FirstOrDefault();
            char secondBoat = Console.ReadLine().FirstOrDefault();
            int numberOfMoves = int.Parse(Console.ReadLine());

            int goal = 50;

            long firstBoatProgress = 0;
            long secondBoatProgress = 0;

            for (int i = 0; i < numberOfMoves; i++)
            {
                string currentLine = Console.ReadLine();

                if (currentLine == "UPGRADE")
                {
                    firstBoat = (char)(firstBoat + 3);
                    secondBoat = (char)(secondBoat + 3);

                    continue;
                }

                if (i % 2 == 0) //first boat
                {
                    firstBoatProgress += currentLine.Length + 1;

                    if (firstBoatProgress > goal)
                    {
                        Console.WriteLine(firstBoat);
                        return;
                    }
                }
                else
                {
                    secondBoatProgress += currentLine.Length + 1;

                    if (secondBoatProgress > goal)
                    {
                        Console.WriteLine(secondBoat);
                        return;
                    }
                }
            }

            if (firstBoatProgress > secondBoatProgress)
            {
                Console.WriteLine(firstBoat);
            }
            else
            {
                Console.WriteLine(secondBoat);
            }
        }
    }
}