using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_8.House_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            long smallerNumber = long.Parse(Console.ReadLine());
            long biggerNumber = long.Parse(Console.ReadLine());

            if (smallerNumber > biggerNumber)
            {
                smallerNumber ^= biggerNumber;
                biggerNumber ^= smallerNumber;
                smallerNumber ^= biggerNumber;
            }

            long housePrice = biggerNumber * 10 + 4 * smallerNumber;

            Console.WriteLine(housePrice);

        }
    }
}