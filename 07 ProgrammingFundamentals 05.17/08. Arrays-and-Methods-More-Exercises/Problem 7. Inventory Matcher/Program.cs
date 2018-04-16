using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main()
    {
        Dictionary<string, Dictionary<long, decimal>> inventory = new Dictionary<string, Dictionary<long, decimal>>();

        string[] items = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        long[] quantities = Console.ReadLine().Split().Select(long.Parse).ToArray();
        decimal[] prices = Console.ReadLine().Split().Select(decimal.Parse).ToArray();

        //for (int i = 0; i < items.Length; i++)
        //{
        //    if (!inventory.ContainsKey(items[i]))
        //    {
        //        inventory.Add(items[i], new Dictionary<long, decimal>());
        //    }
        //    if (!inventory[items[i]].ContainsKey(quantities[i]))
        //    {
        //        inventory[items[i]].Add(quantities[i], prices[i]);
        //    }

        //}

        string input = Console.ReadLine();

        while (input != "done")
        {
            string[] args = input.Split();

            string orderItem = args[0];
            long quantityOrder = long.Parse(args[1]);

            int i = Array.IndexOf(items, orderItem);

            long orderItemQuantity = 0;

            try
            {
                orderItemQuantity = quantities[i];
            }
            catch(IndexOutOfRangeException e)
            {
            }

            if (quantityOrder > orderItemQuantity)
            {
                Console.WriteLine("We do not have enough {0}", orderItem);
                input = Console.ReadLine();
                continue;
            }

            decimal orderPrice = prices[i] * quantityOrder;

            Console.WriteLine("{0} x {1} costs {2:F2}", orderItem, quantityOrder, orderPrice);


            //var quantityAndPrice = inventory[input];
            //var quantity = quantityAndPrice.Keys;
            //var price = quantityAndPrice.Values;

            //

            //Console.WriteLine("{0} costs: {1}; Available quantity: {2}", input, price.FirstOrDefault(), quantity.FirstOrDefault());

            //Console.Write("{0} costs: ", input);

            //Console.Write("{0}; Available quantity: ", string.Join(" ",price));
            //Console.WriteLine("{0}", string.Join(" ", quantity));

            quantities[i] -= quantityOrder;

            input = Console.ReadLine();
        }


    }
}