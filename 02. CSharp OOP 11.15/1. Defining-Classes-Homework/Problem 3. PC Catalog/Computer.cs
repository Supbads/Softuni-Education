using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.PC_Catalog
{
    class Computer
    {
        private IList<Component> components;
        private string name;
        private double price;

        public Computer(string name, double price, Processor processor, GraphicsCard graphicsCard, Motherboard motherboard)
        {
            this.name = name;
            this.price = price;

            components = new List<Component>();
            components.Add(processor);
            components.Add(graphicsCard);
            components.Add(motherboard);
        }


        public double Price
        {
            get { return price; }
            set
            {
                Validator.ValidateDoubleInfo(value);
                price = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                Validator.ValidateNameInfo(value);
                name = value;
            }
        }

        public override string ToString()
        {
            string message = "Computer: " + Name+Environment.NewLine;
            double currentPrice = 0;
            foreach (Component component in components)
            {
                message += component.ToString();
                currentPrice += component.Price;
            }
            message += "Everything costs: " + currentPrice*1.83+"BGN"+Environment.NewLine; //will check
            return message;
        }
    }
}
