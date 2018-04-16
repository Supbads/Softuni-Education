using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Laptop_Shop
{
    class Battery
    {
        private string name;
        private int life;

        public Battery(string name, int life)
        {
            this.Name = name;
            this.Life = life;
        }
        public string Name {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public int Life {
            get { return this.life; }
            set 
            {
                if (value == null || value <= 0) 
                {
                    throw new ArgumentException("battery life must be a positive number");
                }
                this.life = value;
            }
        }

    }
}
