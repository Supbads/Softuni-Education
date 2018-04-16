using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.PC_Catalog
{
    class Program
    {
        static void Main(string[] args)
        {
            // no idea why computer has a price in the first place when we calculate it by summing all other hardware components' sums

            IList<Computer> catalog = new List<Computer>();
            Motherboard mb = new Motherboard("Acer Aspire X3990",460.99);
            GraphicsCard gc = new GraphicsCard("AMD RADEON R9 295X2",659.00);
            Processor proc = new Processor("Intel Core i3-6100",499.99);
            catalog.Add(new Computer("Jivotno",570,proc,gc,mb));
            //
            mb = new Motherboard("MCP61PM-GM",399.99);
            gc = new GraphicsCard("NVIDIA GeForce GTX 980 Ti",869);
            proc = new Processor("Intel Pentium G3258",400);
            catalog.Add(new Computer("Zdrav",488,proc,gc,mb));
            //
            mb = new Motherboard("lazy",200);
            gc = new GraphicsCard("even lazier",149);
            proc = new Processor("sdf",240);
            catalog.Add(new Computer("bavnichak",100,proc,gc,mb));
            //
            var query = catalog.OrderBy(p => p.Price);
            foreach (Computer computer in query)
            {
                Console.WriteLine(computer.ToString());
            }


        }
    }
}
