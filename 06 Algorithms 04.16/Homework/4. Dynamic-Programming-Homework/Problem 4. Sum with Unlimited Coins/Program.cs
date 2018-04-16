namespace Problem_4.Sum_with_Unlimited_Coins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static int targetSum;

        private static int[] coins;

        private static readonly List<List<int>> solutions = new List<List<int>>();

        private static int solutionsCounter = 0;

        private static List<Dictionary<int, int>> indexAmounts = new List<Dictionary<int, int>>();

        static void Main()
        {
			//not dp
			//repeated sets			
            targetSum = int.Parse(Console.ReadLine());
            // 6

            // 1 2 3 4 6
            coins = Console.ReadLine()
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            GenerateSums(0, new List<int>());
            DisplaySolutions();
        }

        private static void GenerateSums(int currentSum, List<int> currentSelectedIndexes)
        {
            if (currentSum > targetSum)
            {
                return;
            }

            if (currentSum == targetSum)
            {
                if (ValidateUniqueSolution(currentSelectedIndexes))
                {
                    solutionsCounter++;
                    solutions.Add(currentSelectedIndexes);
                    return;
                }
            }

            for (int i = 0; i < coins.Length; i++)
            {
                var list = new List<int>(currentSelectedIndexes);
                list.Add(i);
                GenerateSums(currentSum + coins[i], list);
            }
        }

        private static bool ValidateUniqueSolution(List<int> currentSelectedIndexes)
        {

            var currentSolution = new Dictionary<int, int>();
            foreach (int currentIndex in currentSelectedIndexes)
            {
                if (!currentSolution.ContainsKey(currentIndex))
                {
                    currentSolution.Add(currentIndex, 0);
                }

                currentSolution[currentIndex]++;
            }

            foreach (Dictionary<int, int> dictionary in indexAmounts)
            {
                bool everythingMatches = true;
                foreach (KeyValuePair<int, int> indexAndTimes in dictionary)
                {
                    if (!currentSolution.ContainsKey(indexAndTimes.Key))
                    {
                        everythingMatches = false;
                    }
                    
                    if (currentSolution[indexAndTimes.Key] != indexAndTimes.Value)
                    {
                        everythingMatches = false;
                    }
                }

                if (everythingMatches)
                {
                    return false;
                }
            }
            
            return true;
        }

        private static void DisplaySolutions()
        {
            Console.WriteLine("The {0} combinations are:", solutionsCounter);

            foreach (List<int> solution in solutions)
            {
                Console.Write(targetSum + " = ");
                for (int i = 0; i < solution.Count - 1; i++)
                {
                    Console.Write(coins[solution[i]] + " + ");
                }

                Console.Write(coins[solution[solution.Count - 1]]);

                Console.WriteLine();
            }
        }
    }
}
