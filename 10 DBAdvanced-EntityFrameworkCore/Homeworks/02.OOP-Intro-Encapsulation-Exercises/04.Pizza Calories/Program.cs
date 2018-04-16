using System;
using System.Linq;

namespace _04.Pizza_Calories
{
    class Program
    {
        static void Main(string[] args)
        {
            var pizzaName = Console.ReadLine().Substring(6);
            var doughArgs = Console.ReadLine().Split().ToArray();

            try
            {
                var dough = new Dough(doughArgs[1].ToLower(), doughArgs[2].ToLower(), double.Parse(doughArgs[3]));

                var pizza = new Pizza(pizzaName, dough);

                string input = Console.ReadLine();

                while (input != "END")
                {
                    var toppingArgs = input.Split();
                    var topping = new Topping(toppingArgs[1].ToLower(), double.Parse(toppingArgs[2]));

                    try
                    {
                        pizza.AddTopping(topping);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return;
                    }

                    input = Console.ReadLine();
                }

                Console.WriteLine(pizza);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
    }
}