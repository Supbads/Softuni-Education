using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Speed_Racing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<Car> cars = new HashSet<Car>();

            for (int i = 0; i < n; i++)
            {
                var carArgs = Console.ReadLine().Split().ToArray();

                var model = carArgs[0];
                var fuelAmount = float.Parse(carArgs[1]);
                var fuelConsumption = float.Parse(carArgs[2]);

                var car = new Car(fuelAmount, model, fuelConsumption);
                cars.Add(car);
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                var inputArgs = input.Split().ToArray();
                var model = inputArgs[1];
                var distance = int.Parse(inputArgs[2]);

                var currentCar = cars.FirstOrDefault(c => c.Model == model);

                var droveSuccessfully = currentCar.Drive(distance);

                if (!droveSuccessfully)
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }

                input = Console.ReadLine();
            }

            cars.ToList().ForEach(Console.WriteLine);

        }
    }
}