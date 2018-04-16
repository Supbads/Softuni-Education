using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Galactic_GPS
{
    class Program
    {
        static void Main(string[] args)
        {
          
            Location earth = new Location(25.54156, 41.15654, Planet.Earth);
            Console.WriteLine(earth);
            try
            {
                Location somePlace = new Location(-250.3553, 41.15654, Planet.Earth);
                Console.WriteLine(earth);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                dynamic bj = (Planet)Enum.Parse(typeof(Planet), "Bojura");
                Location doma = new Location(25.54156, 41.15654, bj);
            }
            catch (Exception g)
            {
                Console.WriteLine(g.Message);
            }

        }
    }
}
