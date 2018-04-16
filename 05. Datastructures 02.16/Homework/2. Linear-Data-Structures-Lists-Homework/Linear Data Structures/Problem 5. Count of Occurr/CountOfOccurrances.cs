namespace Problem_5.Count_of_Occurr
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CountOfOccurrances
    {
        static void Main(string[] args)
        {
            List<int> numbers =
                Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
            Dictionary<int, int> numberOfOccurForEachNmber = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numberOfOccurForEachNmber.ContainsKey(numbers[i]))
                {
                    continue;
                }

                int currentNumber = numbers[i];
                int currentNumberOccurrances = 1;

                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[j] == currentNumber)
                    {
                        currentNumberOccurrances++;
                    }
                }

                numberOfOccurForEachNmber.Add(currentNumber, currentNumberOccurrances);
            }

            numberOfOccurForEachNmber.OrderBy(k => k.Key);

            foreach (KeyValuePair<int, int> keyValuePair in numberOfOccurForEachNmber.OrderBy(pair => pair.Key)) //I love this from java <3
            {
                Console.WriteLine("{0} -> {1}", keyValuePair.Key, keyValuePair.Value);
            }
        }
    }
}