using System;
using System.Collections.Generic;

namespace Problem2.Vapor_Store
{
    class VaporStore
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> gamesByPrice = new Dictionary<string, decimal>();

            FillDictionary(gamesByPrice);

            decimal moneyAmount = decimal.Parse(Console.ReadLine());
            decimal moneySpent = 0m;

            string input = Console.ReadLine();

            while (input != "Game Time")
            {
                //if (moneyAmount == 0m)
                //{
                //    Console.WriteLine("Out of money!");
                //    return;

                //}

                if (!gamesByPrice.ContainsKey(input))
                {
                    Console.WriteLine("Not Found");
                }
                else if (gamesByPrice[input] > moneyAmount)
                {
                    Console.WriteLine("Too Expensive");
                }
                else
                {
                    decimal gamePrice = gamesByPrice[input];

                    moneyAmount -= gamePrice;
                    moneySpent += gamePrice;

                    Console.WriteLine("Bought " + input);
                }


                input = Console.ReadLine();
            }

            Console.WriteLine("Total spent: ${0}. Remaining: ${1}", moneySpent.ToString("0.00"), moneyAmount.ToString("0.00"));

        }

        static void FillDictionary(Dictionary<string,decimal> gamesByPrice)
        {
            if (gamesByPrice == null)
            {
                gamesByPrice = new Dictionary<string, decimal>();
            }

            gamesByPrice.Add("OutFall 4", 39.99m);
            gamesByPrice.Add("CS: OG", 15.99m);
            gamesByPrice.Add("Zplinter Zell", 19.99m);
            gamesByPrice.Add("Honored 2", 59.99m);
            gamesByPrice.Add("RoverWatch", 29.99m);
            gamesByPrice.Add("RoverWatch Origins Edition", 39.99m);
        }
    }
}