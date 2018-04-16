using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Karate_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("0123456789".Remove(3,3)); //0126789 output
            //Console.WriteLine("0123456789".Remove(3, 7)); //012 output

            string input = Console.ReadLine();

            int remainingStrength = 0;
            for (int i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];
                if (currentChar != '>')
                {
                    continue;
                }

                var strengthChar = input[i + 1];

                int strength = int.Parse(strengthChar.ToString()) + remainingStrength;

                int j = i + 1;
                while (j < input.Length && input[j] != '>' && strength > 0)
                {
                    input = input.Remove(j, 1);
                    strength--;
                }

                remainingStrength = strength;
            }

            Console.WriteLine(input);


        }
    }
}
