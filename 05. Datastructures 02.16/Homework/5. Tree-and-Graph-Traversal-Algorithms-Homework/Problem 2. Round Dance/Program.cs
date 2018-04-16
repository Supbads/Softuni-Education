namespace Problem_2.Round_Dance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static int numberOfEdges;

        private static bool firstIteration = true;

        private static int longestPath;

        private static readonly Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();

        //backtracking ?
        private static bool[] visited;

        private static Tree<int> danceLeader;

        static void Main(string[] args)
        {
            numberOfEdges = int.Parse(Console.ReadLine());
            int biggestNodeValue = 0;

            var leader = int.Parse(Console.ReadLine());
            danceLeader = GetTreeNodeByValue(leader);

            for (int i = 0; i < numberOfEdges; i++)
            {
                int[] nodes = Console.ReadLine()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                var firstNode = GetTreeNodeByValue(nodes[0]);
                var secondNode = GetTreeNodeByValue(nodes[1]);

                if (firstNode.Value > biggestNodeValue)
                {
                    biggestNodeValue = firstNode.Value;
                }
                if (secondNode.Value > biggestNodeValue)
                {
                    biggestNodeValue = secondNode.Value;
                }

                secondNode.AddChild(firstNode);
                firstNode.AddChild(secondNode);
            }

            visited = new bool[biggestNodeValue + 1];

            visited[danceLeader.Value] = true;
            foreach (Tree<int> child in danceLeader.Children)
            {
                RunDfSToFindLongestDance(child, 2); 
            }

            Console.WriteLine(longestPath);

        }

        private static void RunDfSToFindLongestDance(Tree<int> node, int counter)
        {
            if (visited[node.Value])
            {
                return;
            }

            visited[node.Value] = true;

            if (counter > longestPath)
            {
                longestPath = counter;
            }

            foreach (Tree<int> child in node.Children)
            {
                RunDfSToFindLongestDance(child, counter + 1);
            }
        }
        
        private static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }

            return nodeByValue[value];
        }
    }
}