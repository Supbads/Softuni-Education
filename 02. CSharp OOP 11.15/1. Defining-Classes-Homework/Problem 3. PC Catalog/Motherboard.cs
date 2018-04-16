using System;

namespace Problem_3.PC_Catalog
{
    class Motherboard : Component
    {
        
        public Motherboard(string name, double price) : base(name, price)
        {
        }

        public override string ToString()
        {
            return "Motherboard: " + this.Name + " costs: " + "$" + this.Price + Environment.NewLine;
        }
    }
}
