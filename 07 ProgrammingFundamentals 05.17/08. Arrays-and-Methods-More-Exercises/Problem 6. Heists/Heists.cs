using System;
using System.Linq;

class Heists
{
    static void Main(string[] args)
    {
        long[] prices = Console.ReadLine().Split().Select(long.Parse).ToArray();

        long priceOfJewels = prices[0];
        long priceOfGold = prices[1];

        long heists = 0;
        long totalLoot = 0;

        string input = Console.ReadLine();

        //% - jewels   $ - gold
        long jewelsCount = 0;
        long goldCount = 0;

        while (input != "Jail Time")
        {
            string[] tokens = input.Split();
            heists += long.Parse(tokens[1]);
            string loot = tokens[0];

            for (int i = 0; i < loot.Length; i++)
            {
                if (loot[i] == '%')
                {
                    jewelsCount++;
                }
                if (loot[i] == '$')
                {
                    goldCount++;
                }

            }

            input = Console.ReadLine();
        }

        totalLoot += jewelsCount * priceOfJewels;
        totalLoot += goldCount * priceOfGold;

        if (totalLoot >= heists)
        {
            Console.WriteLine("Heists will continue. Total earnings: {0}.", totalLoot - heists);
        }
        else
        {
            Console.WriteLine("Have to find another job. Lost: {0}.", heists - totalLoot);
        }

    }
}