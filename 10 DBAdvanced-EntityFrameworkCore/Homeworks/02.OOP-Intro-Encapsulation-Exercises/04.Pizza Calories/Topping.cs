using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Pizza_Calories
{
    class Topping
    {
        private const double meat = 1.2;
        private const double veggies = 0.8;
        private const double cheese = 1.1;
        private const double sauce = 0.9;

        private const double baseCalories = 2;

        private string toppingName;

        private double weight;

        public Topping(string type, double weight)
        {
            this.ToppingName = type;
            this.Weight = weight;
        }

        public string ToppingName
        {
            get { return this.toppingName; }

            private set
            {
                if (value != "meat" && value != "veggies" && value != "cheese" && value != "sauce")
                {
                    var str = value[0].ToString().ToUpper() + value.Substring(1);
                    throw new Exception($"Cannot place {str} on top of your pizza.");
                }

                this.toppingName = value;
            }
        }

        public double Weight
        {
            get { return this.weight; }

            private set
            {
                if (value < 1 || value > 50)
                {
                    var str = this.toppingName[0].ToString().ToUpper() + this.toppingName.Substring(1);
                    throw new Exception($"{str} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public double Calories()
        {
            return baseCalories * ToppingCalories() * this.weight;
        }

        private double ToppingCalories()
        {
            if (this.toppingName == "meat")
            {
                return meat;
            }
            else if (this.toppingName == "veggies")
            {
                return veggies;
            }
            else if (this.toppingName == "cheese")
            {
                return cheese;
            }
            else
            {
                return sauce;
            }
        }


    }
}
