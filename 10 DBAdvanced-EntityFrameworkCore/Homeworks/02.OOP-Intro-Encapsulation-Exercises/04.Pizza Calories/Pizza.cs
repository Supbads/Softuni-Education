using System;
using System.Collections.Generic;

namespace _04.Pizza_Calories
{
    class Pizza
    {
        private string name;

        private int numberOfToppings;

        public Dough Dough { get; set; }

        public List<Topping> Toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.Toppings = new List<Topping>();
        }

        public int NumberOfToppings
        {
            get { return this.numberOfToppings;  }
            set
            {
                if (value > 10)
                {
                    throw new Exception("Number of toppings should be in range [0..10].");
                }

                this.numberOfToppings = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value.Length > 15 || value == "")
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            this.Toppings.Add(topping);
            this.NumberOfToppings += 1;
        }

        public double Calories()
        {
            double totalCalories = 0;
            foreach (Topping topping in Toppings)
            {
                totalCalories += topping.Calories();
            }

            totalCalories += this.Dough.Calories();

            return totalCalories;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1:F2} Calories.", this.Name, this.Calories());
        }
    }
}