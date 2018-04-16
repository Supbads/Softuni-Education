namespace Longest_Common_Subsequence
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LongestCommonSubsequence
    {
        public static void Main()
        {
            var firstStr = "tree";
            var secondStr = "team";

            var lcs = FindLongestCommonSubsequence(firstStr, secondStr);

            Console.WriteLine("Longest common subsequence:");
            Console.WriteLine("  first  = {0}", firstStr);
            Console.WriteLine("  second = {0}", secondStr);
            Console.WriteLine("  lcs    = {0}", lcs);
        }

        public static string FindLongestCommonSubsequence(string firstStr, string secondStr)
        {
            int firstLength = firstStr.Length + 1;
            int secondLength = secondStr.Length + 1;
            var lcs = new int[firstLength, secondLength];

            for (int i = 1; i < firstLength; i++)
            {
                for (int j = 1; j < secondLength; j++)
                {
                    if (firstStr[i - 1] == secondStr[j - 1])
                    {
                        lcs[i, j] = lcs[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        lcs[i, j] = Math.Max(lcs[i - 1, j], lcs[i, j - 1]);
                    }
                }
            }

            var sequance = RetrieveLCS(firstStr, secondStr, lcs);
            StringBuilder sb = new StringBuilder(sequance.Length);
            foreach (char c in sequance)
            {
                sb.Append(c);
            }

            return sb.ToString();
        }

        static char[] RetrieveLCS(string firstStr, string secondStr, int[,] lcs)
        {
            List<char> longestCommonSubsequance = new List<char>(Math.Min(firstStr.Length, secondStr.Length));

            int i = lcs.GetLength(0) - 1;
            int j = lcs.GetLength(1) - 1;

            while (i > 0 && j > 0)
            {
                if (firstStr[i - 1] == secondStr[j - 1])
                {
                    longestCommonSubsequance.Add(firstStr[i - 1]);
                    i--;
                    j--;
                }
                else if (lcs[i, j] == lcs[i - 1, j])
                {
                    i--;
                }
                else
                {
                    j--;
                }
            }

            longestCommonSubsequance.Reverse();
            return longestCommonSubsequance.ToArray();
        }
    }
}
