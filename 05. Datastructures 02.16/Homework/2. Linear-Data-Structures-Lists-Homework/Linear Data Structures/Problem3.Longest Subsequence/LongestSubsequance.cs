namespace Problem3.Longest_Subsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LongestSubsequance
    {
        static void Main(string[] args)
        {
            List<int> numbers =
                Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

            int currentBestSubsequanceLength = -1;
            int currentSubsequanceLength;
            int currentBestIndex = -1;

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                currentSubsequanceLength = 1;
                int j = i;
                while (j + 1 < numbers.Count && (numbers[j] == numbers[j + 1]))
                {
                    currentSubsequanceLength++;
                    if (currentSubsequanceLength > currentBestSubsequanceLength)
                    {
                        currentBestSubsequanceLength = currentSubsequanceLength;
                        currentBestIndex = i;
                    }

                    j++;
                }
            }

            for (int i = currentBestIndex; i < currentBestSubsequanceLength + currentBestIndex; i++)
            {
                Console.Write(numbers[i] + " ");
            }
        }
    }
}