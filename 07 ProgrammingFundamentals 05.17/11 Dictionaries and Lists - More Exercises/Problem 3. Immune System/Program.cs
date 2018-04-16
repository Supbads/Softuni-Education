using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Immune_System
{
    class Program
    {
        static void Main(string[] args)
        {
            //virus’ strength before it fights it. It is the sum of all the virus name’s letters’ ASCII codes, divided by 3.
            //to defeat a virus in seconds. It is equal to the virus strength, multiplied by the length of the virus’ name.
            //convert it to minutes and seconds (500  8m 20s). Do not use any leading zeroes for the minutes and seconds
            //After a virus is defeated, the immune system regains 20% of its strength. If the 20 percent exceeds the initial health of the immune system, set it to the initial health instead.


            //need list of encounters 
            HashSet<string> listOfVirusesEncountered = new HashSet<string>();



            int startingHealth = int.Parse(Console.ReadLine()); //need to coppy
            int currentHealth = startingHealth;

            bool isDefeated = false;

            string virus = Console.ReadLine();
            while (virus != "end")
            {
                int totalSeconds = 0;
                int currentMinutes = 0;
                int currentSeconds = 0;

                //Virus flu1: 125 => 166 seconds
                //flu1 defeated in 2m 46s.
                
                int timeDivider = 3;
                if (!listOfVirusesEncountered.Contains(virus))
                {
                    listOfVirusesEncountered.Add(virus);
                    timeDivider = 1;
                }

                int virusStength = CalculateVirusStrength(virus);
                int virusNameLength = virus.Length;
                totalSeconds = (int)Math.Floor(virusNameLength * virusStength / (double)timeDivider);

                currentMinutes = totalSeconds / 60;
                currentSeconds = totalSeconds % 60;


                Console.WriteLine("Virus {0}: {1} => {2} seconds", virus, virusStength, totalSeconds);

                if (totalSeconds > currentHealth) // >=
                {
                    isDefeated = true;
                    break;
                }
                else
                {
                    Console.WriteLine("{0} defeated in {1}m {2}s.",virus, currentMinutes, currentSeconds);
                    currentHealth -= totalSeconds;

                    Console.WriteLine("Remaining health: {0}", currentHealth);

                    //regenerate 20%
                    currentHealth = Math.Min(startingHealth, currentHealth + currentHealth * 20 / 100);
                }

                virus = Console.ReadLine();
            }


            if (!isDefeated)
            {
                Console.WriteLine("Final Health: {0}", currentHealth);
            }
            else
            {
                Console.WriteLine("Immune System Defeated.");
            }

        }

        private static int CalculateVirusStrength(string virusName)
        {
            double sum = 0;

            for (int i = 0; i < virusName.Length; i++)
            {
                sum += (int)virusName[i];
            }

            return (int)Math.Floor(sum / 3);
        }
    }
}
