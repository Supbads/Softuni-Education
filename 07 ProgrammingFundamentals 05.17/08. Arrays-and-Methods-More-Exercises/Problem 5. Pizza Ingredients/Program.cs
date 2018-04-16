using System;
using System.Collections.Generic;

namespace Problem_5.Pizza_Ingredients
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ingredients = Console.ReadLine().Split();

            int length = int.Parse(Console.ReadLine());

            int ingredientsCount = 0;
            List<string> selectedIngredients = new List<string>();

            for (int i = 0; i < ingredients.Length; i++)
            {
                if (ingredients[i].Length == length)
                {
                    Console.WriteLine("Adding {0}.",ingredients[i]);
                    selectedIngredients.Add(ingredients[i]);

                    ingredientsCount++;
                }
                if (ingredientsCount == 10)
                {
                    break;
                }

            }

            Console.WriteLine("Made pizza with total of {0} ingredients.", ingredientsCount);

            Console.WriteLine("The ingredients are: {0}.", string.Join(", ", selectedIngredients));

        }
    }
}