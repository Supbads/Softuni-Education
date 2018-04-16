using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Vehicle_Catalogue
{
    public enum Type
    {
        Car,
        Truck
    }

    class Vehicle
    {
        public Vehicle(Type type, string model, string color, int horsepower)
        {
            this.Type = type;
            Model = model;
            Color = color;
            Horsepower = horsepower;
        }

        public Type Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int Horsepower { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //maybe horsepower should be double
            Dictionary<string, Vehicle> modelAndVehicle = new Dictionary<string, Vehicle>();
            //Dictionary<string, List<Vehicle>> typesAndVehicles = new Dictionary<string, List<Vehicle>>();


            string input = Console.ReadLine();

            while (input != "End")
            {
                var tokens = input.Split();

                string currentModel = tokens[1];
                string currentColor = tokens[2];
                var currentHorsepower = int.Parse(tokens[3]);

                Type currentType = Type.Car;
                if (tokens[0].ToLower() == "truck")
                {
                    currentType = Type.Truck;
                }

                var currentVehicle = new Vehicle(currentType, currentModel, currentColor, currentHorsepower);

                if (!modelAndVehicle.ContainsKey(currentModel))
                {
                    modelAndVehicle.Add(currentModel, currentVehicle);
                }
                else
                {
                    modelAndVehicle[currentModel] = currentVehicle;
                }

                input = Console.ReadLine();
            }

            string requestedModel = Console.ReadLine();

            while (requestedModel != "Close the Catalogue")
            {
                if (modelAndVehicle.ContainsKey(requestedModel))
                {
                    var currentVehicle = modelAndVehicle[requestedModel];

                    Console.WriteLine("Type: {0}", currentVehicle.Type);
                    Console.WriteLine("Model: {0}", currentVehicle.Model);
                    Console.WriteLine("Color: {0}", currentVehicle.Color);
                    Console.WriteLine("Horsepower: {0}", currentVehicle.Horsepower);
                }

                requestedModel = Console.ReadLine();
            }

            //Cars have average horsepower of: 413.33.
            //Trucks have average horsepower of: 250.00.


            double carsAverageHorsepower = 0;
            if (modelAndVehicle.Values.Any(x => x.Type == Type.Car))
            {
                carsAverageHorsepower = modelAndVehicle.Values.Where(x => x.Type == Type.Car)
                    .Average(y => y.Horsepower);
            }

            double trucksAverageHorsepower = 0;

            if (modelAndVehicle.Values.Any(x => x.Type == Type.Truck))
            {
                trucksAverageHorsepower = modelAndVehicle.Values.Where(x => x.Type == Type.Truck)
                    .Average(y => y.Horsepower);
            }

            Console.WriteLine("Cars have average horsepower of: {0:F2}.", carsAverageHorsepower);
            Console.WriteLine("Trucks have average horsepower of: {0:F2}.", trucksAverageHorsepower);

        }
    }
}
