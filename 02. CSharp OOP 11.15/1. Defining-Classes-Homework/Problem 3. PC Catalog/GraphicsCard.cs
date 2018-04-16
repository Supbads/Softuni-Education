using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.PC_Catalog
{
    class GraphicsCard : Component
    {
        public GraphicsCard(string name, double price) : base(name, price)
        {
        }

        public override string ToString()
        {
            return "Graphics card: " + this.Name + " costs: " + this.Price +"$" + Environment.NewLine;
        }
    }
}
