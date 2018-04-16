using System.Collections.Generic;

namespace _03.Raw_Data
{
    class Car
    {
        public Car(string model, int engineSpeed, int enginePower,
            int cargoWeight, string cargoType,
            double tire1Pressure, int tire1Age,
            double tire2Pressure, int tire2Age,
            double tire3Pressure, int tire3Age,
            double tire4Pressure, int tire4Age)
        {
            this.Model = model;

            this.Engine = new Engine(engineSpeed, enginePower);
            this.Cargo = new Cargo(cargoWeight, cargoType);
            this.Tires = new List<Tire>();
            Tire first = new Tire(tire1Pressure, tire1Age);
            Tire second = new Tire(tire2Pressure, tire2Age);
            Tire third = new Tire(tire3Pressure, tire3Age);
            Tire fourth = new Tire(tire4Pressure, tire4Age);
            Tires.Add(first);
            Tires.Add(second);
            Tires.Add(third);
            Tires.Add(fourth);
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public List<Tire> Tires { get; set; }

        public override string ToString()
        {
            return Model;
        }
    }
}