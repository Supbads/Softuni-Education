using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            var shorterString = input[0];
            var longerString = input[1];

            if (shorterString.Length > longerString.Length)
            {
                var temp = shorterString;
                shorterString = longerString;
                longerString = temp;
            }


            long sum = 0;

            for (int i = 0; i < longerString.Length; i++)
            {
                if (i >= shorterString.Length)
                {
                    sum += (int) longerString[i];
                    continue;
                }


                long currentSum = longerString[i] * shorterString[i];
                sum += currentSum;
            }

            Console.WriteLine(sum);

        }
    }
}
