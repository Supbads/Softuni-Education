using System;

namespace Problem4.Beverage_Labels
{
    class BeverageLabels
    {
        static void Main(string[] args)
        {
            var beverageName = Console.ReadLine();
            var volume = int.Parse(Console.ReadLine());
            var energyContent = int.Parse(Console.ReadLine());
            var sugarContent = int.Parse(Console.ReadLine());

            double energyContentForCurrentDrink = (double)volume * energyContent / 100;
            double sugarContentForCurrentDrink = (double)volume / 100 * sugarContent;


            Console.WriteLine(volume+"ml "+ beverageName + ":");
            Console.Write("{0}kcal, {1}g sugars", energyContentForCurrentDrink, sugarContentForCurrentDrink);
        }
    }
}
