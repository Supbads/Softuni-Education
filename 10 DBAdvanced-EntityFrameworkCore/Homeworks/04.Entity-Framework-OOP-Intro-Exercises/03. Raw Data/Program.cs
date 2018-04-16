using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Raw_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var carArgs = Console.ReadLine().Split();

                var model = carArgs[0];

                var engineSpeed = int.Parse(carArgs[1]);
                var enginePower = int.Parse(carArgs[2]);

                var cargoWeight = int.Parse(carArgs[3]);
                var cargoType = carArgs[4];

                var tire1Pressure = double.Parse(carArgs[5]);
                int tire1Age = int.Parse(carArgs[6]);

                var tire2Pressure = double.Parse(carArgs[7]);
                int tire2Age = int.Parse(carArgs[8]);

                var tire3Pressure = double.Parse(carArgs[9]);
                int tire3Age = int.Parse(carArgs[10]);

                var tire4Pressure = double.Parse(carArgs[11]);
                int tire4Age = int.Parse(carArgs[12]);

                var car = new Car(model,
                    engineSpeed, enginePower,
                    cargoWeight, cargoType,
                    tire1Pressure, tire1Age,
                    tire2Pressure, tire2Age,
                    tire3Pressure, tire3Age,
                    tire4Pressure, tire4Age);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                var fragileCars = cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1));
                Console.WriteLine(string.Join("\r\n", fragileCars));
                
            }
            else
            {
                var flammableCars = cars.Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250);
                Console.WriteLine(string.Join("\r\n", flammableCars));
            }
        }
    }
}