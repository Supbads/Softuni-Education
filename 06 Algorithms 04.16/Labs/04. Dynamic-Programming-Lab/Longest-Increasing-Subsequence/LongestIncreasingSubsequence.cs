namespace Longest_Increasing_Subsequence
{
    using System;
    using System.Collections.Generic;

    public class LongestIncreasingSubsequence
    {
        public static void Main()
        {
            var sequence = new[] { 3, 14, 5, 12, 15, 7, 8, 9, 11, 10, 1 };
            var longestSeq = FindLongestIncreasingSubsequence(sequence);
            Console.WriteLine("Longest increasing subsequence (LIS)");
            Console.WriteLine("  Length: {0}", longestSeq.Length);
            Console.WriteLine("  Sequence: [{0}]", string.Join(", ", longestSeq));
        }

        public static int[] FindLongestIncreasingSubsequence(int[] sequence)
        {
            int[] lengths = new int[sequence.Length];
            int[] previous  = new int[sequence.Length];

            int maxLength = 0;
            int lastIndex = -1;
            
            for (int i = 0; i < sequence.Length; i++)
            {
                lengths[i] = 1;
                previous[i] = -1;
                for (int j = 0; j < i; j++)
                {
                    if (sequence[j] < sequence[i] && lengths[j] >= lengths[i])
                    {
                        lengths[i] = lengths[j] + 1;
                        previous[i] = j;
                    }
                }

                if (lengths[i] > maxLength)
                {
                    maxLength = lengths[i];
                    lastIndex = i;
                }
            }

            var longestIncreasingSubsequance = new List<int>();
            while (lastIndex != -1)
            {
                longestIncreasingSubsequance.Add(sequence[lastIndex]);
                lastIndex = previous[lastIndex];
            }

            longestIncreasingSubsequance.Reverse();
            return longestIncreasingSubsequance.ToArray();
        }
    }
}
