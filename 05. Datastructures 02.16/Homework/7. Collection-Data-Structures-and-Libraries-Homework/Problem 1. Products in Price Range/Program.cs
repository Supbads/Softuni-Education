namespace Problem_1.Products_in_Price_Range
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    class Program
    {
        static void Main(string[] args)
        {
            /* 
7
apples 2.50
bananas 1.20
milk 1.33
water 1.30
beer 0.95
cheese 8.5
muffin 0.5
0.95 2               
            */

            var fruitPrices = new OrderedDictionary<decimal, string>();
            var numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                var inputTokens = Console.ReadLine().Split();
                fruitPrices[decimal.Parse(inputTokens[1])] = inputTokens[0];
            }

            var range = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
            var elementsInGivenRange = fruitPrices.Range(range[0], true, range[1], true);

            foreach (KeyValuePair<decimal, string> priceFruit in elementsInGivenRange)
            {
                Console.WriteLine("{0} {1}", priceFruit.Key, priceFruit.Value);
            }
        }
    }
}