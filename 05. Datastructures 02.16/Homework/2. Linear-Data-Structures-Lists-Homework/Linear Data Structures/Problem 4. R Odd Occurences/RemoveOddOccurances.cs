namespace Problem_4.R_Odd_Occurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class RemoveOddOccurances
    {
        static void Main(string[] args)
        {
            List<int> numbers =
                Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

            List<int> passingNumbers = new List<int>();
            List<int> numberOfEvenOccurancesOfPassingNumbers = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumberOfOccurances = 1;
                int currentNumber = numbers[i];

                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[j] == currentNumber)
                    {
                        currentNumberOfOccurances++;
                    }
                }

                if (currentNumberOfOccurances % 2 == 0)
                {
                    passingNumbers.Add(currentNumber);
                    numberOfEvenOccurancesOfPassingNumbers.Add(currentNumberOfOccurances);
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < passingNumbers.Count; i++)
            {

                for (int j = 0; j < numberOfEvenOccurancesOfPassingNumbers[i]; j++)
                {
                    sb.Append(numbers[i] + " ");
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
