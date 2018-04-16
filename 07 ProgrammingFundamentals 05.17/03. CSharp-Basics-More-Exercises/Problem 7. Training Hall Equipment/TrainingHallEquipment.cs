using System;

namespace Problem_7.Training_Hall_Equipment
{

    class TrainingHallEquipment
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());

            decimal totalPriceOfBoughtItems = 0;

            short numberOfItemsToBuy = short.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfItemsToBuy; i++)
            {
                string nameOfItemBought = Console.ReadLine();
                decimal priceOfItemBought = decimal.Parse(Console.ReadLine());
                int numberOfItemsBought = int.Parse(Console.ReadLine());

                totalPriceOfBoughtItems += priceOfItemBought * numberOfItemsBought;

                if (numberOfItemsBought > 1)
                {
                    Console.WriteLine("Adding {0} {1}s to cart.", numberOfItemsBought, nameOfItemBought);
                }
                else
                {
                    Console.WriteLine("Adding {0} {1} to cart.", numberOfItemsBought, nameOfItemBought);
                }
            }

            if (totalPriceOfBoughtItems > budget)
            {
                Console.WriteLine("Subtotal: ${0:F2}", totalPriceOfBoughtItems);
                Console.WriteLine("Not enough. We need ${0:F2} more.", totalPriceOfBoughtItems - budget);
            }
            else
            {
                Console.WriteLine("Subtotal: ${0:F2}",totalPriceOfBoughtItems);
                Console.WriteLine("Money left: ${0:F2}",budget-totalPriceOfBoughtItems);
            }
        }
    }
}
