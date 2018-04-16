using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1.Debit_Card_Number
{
    class Program
    {
        static int defaultPadNumber = 4;

        static char defaultPadSymbol = '0';

        static void Main(string[] args)
        {
            StringBuilder sbuilder = new StringBuilder();
            
            for (int i = 0; i < 4; i++)
            {
                var input = Console.ReadLine();

                sbuilder.Append(input + " ");
            }

            string inputNumbers = sbuilder.ToString();

            var numbers = inputNumbers.Split(new[] { " ", "\n", ",", "\r" }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var paddedNumbers = numbers.Select(x => x.PadLeft(defaultPadNumber, defaultPadSymbol));

            foreach (var paddedNumber in paddedNumbers)
            {
                Console.Write(paddedNumber + " ");
            }

        }
    }
}
