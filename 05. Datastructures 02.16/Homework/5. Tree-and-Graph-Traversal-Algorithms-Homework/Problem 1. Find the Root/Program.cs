namespace Problem_1.Find_the_Root
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static readonly Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();

        private static int numberOfNodes;

        private static bool[] visitedNodes;

        static void Main(string[] args)
        {
            numberOfNodes = int.Parse(Console.ReadLine());
            int numberOfEdges = int.Parse(Console.ReadLine());
            visitedNodes = new bool[numberOfNodes];

            for (int i = 0; i < numberOfEdges; i++)
            {
                int[] nodes = Console.ReadLine()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                var firstNode = GetTreeNodeByValue(nodes[0]);
                var secondNode = GetTreeNodeByValue(nodes[1]);

                secondNode.Parent = firstNode;
                firstNode.AddChild(secondNode);
            }

            var rootNodes = RunDFSToFindRoot();
            Console.WriteLine();
            if (rootNodes.Count == 0)
            {
                Console.WriteLine("No root!");
            }
            else if (rootNodes.Count > 1)
            {
                Console.WriteLine("Multiple root nodes!");
            }
            else
            {
                Console.WriteLine(rootNodes[0].Value); 
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

        private static List<Tree<int>> RunDFSToFindRoot()
        {

            List<Tree<int>> rootNodes = new List<Tree<int>>();
            Stack<Tree<int>> nodesToSearch = new Stack<Tree<int>>();

            foreach (KeyValuePair<int, Tree<int>> nodePair in nodeByValue)
            {
                var node = nodePair.Value;

                if (visitedNodes[node.Value])
                {
                    continue;
                }

                //visitedNodes[node.Value] = true;

                nodesToSearch.Push(node);

                while (nodesToSearch.Count > 0)
                {
                    var poppedNode = nodesToSearch.Pop();

                    if (visitedNodes[poppedNode.Value])
                    {
                        continue;
                    }

                    if (poppedNode.Parent == null)
                    {
                        rootNodes.Add(poppedNode);
                    }

                    visitedNodes[poppedNode.Value] = true;
                    foreach (Tree<int> childNodes in poppedNode.Children)
                    {
                        nodesToSearch.Push(childNodes);
                    }
                }
            }

            return rootNodes;
        }
    }
}
