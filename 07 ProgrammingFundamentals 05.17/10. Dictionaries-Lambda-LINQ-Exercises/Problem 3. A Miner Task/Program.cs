using System;
using System.Collections.Generic;

namespace Problem_3.A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> resourcesAndQuantity = new Dictionary<string, long>();

            string type = Console.ReadLine();

            while (type != "stop")
            {
                long quantity = long.Parse(Console.ReadLine());

                if (!resourcesAndQuantity.ContainsKey(type))
                {
                    resourcesAndQuantity.Add(type, quantity);
                }
                else
                {
                    resourcesAndQuantity[type] += quantity;
                }
                
                
                

                type = Console.ReadLine();
            }


            foreach (var resourceAndQuantityPair in resourcesAndQuantity)
            {
                Console.WriteLine("{0} -> {1}", resourceAndQuantityPair.Key, resourceAndQuantityPair.Value);
            }

        }
    }
}
