using System;

namespace Problem_3.PC_Catalog
{
    class Processor : Component
    {
        public Processor(string name, double price) : base(name, price)
        {
        }

        public override string ToString()
        {
            return "Processor: " + this.Name + " costs: " + "$" + this.Price + Environment.NewLine;
        }
    }
}
