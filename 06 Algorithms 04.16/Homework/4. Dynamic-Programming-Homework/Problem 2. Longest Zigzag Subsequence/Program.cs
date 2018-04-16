namespace Problem_2.Longest_Zigzag_Subsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            if (numbers.Length < 2)
            {
                Console.WriteLine(string.Join(" ", numbers));
                return;
            }

            int[,] differencesTable = new int[numbers.Length, 2];
            // 0 -> positive 
            // 1 -> negative

            //int biggestSequanceCounter = 0;

            var biggestSequanceIndex = 0;
            var positiveDifference = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                differencesTable[i, 0] = differencesTable[i, 1] = 0;

                for (int j = 0; j < i; j++)
                {
                    if (numbers[i] > numbers[j]) // positive difference
                    {
                        differencesTable[i, 0] = Math.Max(differencesTable[j, 1] + 1, differencesTable[i, 0]);
                        if (differencesTable[i, 0] > biggestSequanceIndex)
                        {
                            biggestSequanceIndex = i;
                            positiveDifference = true;
                        }
                    }
                    else // negative difference
                    {
                        differencesTable[i, 1] = Math.Max(differencesTable[j, 0] + 1, differencesTable[i, 1]);
                        if (differencesTable[i, 1] > biggestSequanceIndex)
                        {
                            biggestSequanceIndex = i;
                            positiveDifference = false;
                        }
                    }
                }

                //if (differencesTable[i, 1] >= biggestSequanceCounter || differencesTable[i, 0] >= biggestSequanceCounter)
                //{
                //    biggestSequanceCounter = Math.Max(differencesTable[i, 1], differencesTable[i, 0]);
                //    biggestSequanceCounter++;
                //}
            }
            // Console.WriteLine(biggestSequanceCounter);

            // Try to restore
            List<int> sequance = new List<int>();
            var lastIteration = false;

            while (!lastIteration)
            {
                if (biggestSequanceIndex == 0)
                {
                    lastIteration = true;
                }

                sequance.Add(numbers[biggestSequanceIndex]);
                var currentMax = biggestSequanceIndex;

                if (!positiveDifference)
                {
                    for (int i = 0; i < biggestSequanceIndex; i++)
                    {
                        if (differencesTable[i, 0] < differencesTable[biggestSequanceIndex, 1]
                            && numbers[i] > numbers[biggestSequanceIndex])
                        {
                            currentMax = i;
                        }
                    }
                }

                else
                {
                    for (int i = 0; i < biggestSequanceIndex; i++)
                    {
                        if (differencesTable[i, 1] < differencesTable[biggestSequanceIndex, 0]
                            && numbers[i] < numbers[biggestSequanceIndex])
                        {
                            currentMax = i;
                        }
                    }
                }

                positiveDifference = !positiveDifference;

                biggestSequanceIndex = currentMax;
            }
            
            sequance.Reverse();

            Console.WriteLine(string.Join(" ", sequance));
        }
    }
}
