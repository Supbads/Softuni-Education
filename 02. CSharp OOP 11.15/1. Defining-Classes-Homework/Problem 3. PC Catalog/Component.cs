using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.PC_Catalog
{
    public abstract class Component
    {
        private string name;
        private double price;

        protected Component(string name,double price)
        {
            this.Name = name;
            this.Price = price;
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

        public double Price
        {
            get { return price; }
            set
            {
                Validator.ValidateDoubleInfo(value);
                price = value;
            }
        }

        public abstract override string ToString();
    }
}
