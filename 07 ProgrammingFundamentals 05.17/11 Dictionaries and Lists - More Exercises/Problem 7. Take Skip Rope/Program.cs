using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_7.Take_Skip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            List<char> inputWithoutDigits = new List<char>();
            List<int> numbers = new List<int>();

            List<int> skipNumbers = new List<int>();
            List<int> takeNumbers = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                int number;
                if (int.TryParse(input[i].ToString(), out number))
                {
                    numbers.Add(number);
                }
                else
                {
                 inputWithoutDigits.Add(input[i]);   
                }
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeNumbers.Add(numbers[i]);
                }
                else
                {
                    skipNumbers.Add(numbers[i]);
                }
            }

            StringBuilder result = new StringBuilder();

            int sumSkipped = 0;
            for (int i = 0; i < skipNumbers.Count; i++)
            {
                var skipNmber = skipNumbers[i];
                var takeNumber = takeNumbers[i];

                int j = sumSkipped;
                int k = 0;
                while (j < inputWithoutDigits.Count && k < takeNumber)
                {
                    result.Append(inputWithoutDigits[j]);

                    k++;
                    j++;
                }

                sumSkipped += skipNmber + takeNumber;
            }


            Console.WriteLine(result.ToString());

        }
    }
}