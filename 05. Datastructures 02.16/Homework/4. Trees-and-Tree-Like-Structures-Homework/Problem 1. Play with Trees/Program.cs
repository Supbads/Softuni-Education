namespace Problem_1.Play_with_Trees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>(); 

        static Stack<Tree<int>> pathHelper = new Stack<Tree<int>>();

        static List<Tree<int>> leafs = new List<Tree<int>>();

        private static Stack<Tree<int>> longestPathHelper = new Stack<Tree<int>>();

        private static Stack<Tree<int>> longestPath = new Stack<Tree<int>>(); 

        private static int pathTargetSum;

        private static int subtreeTargetSum;

        private static int currentLongestPath = 0;

        static void Main()
        {
            int nodes = int.Parse(Console.ReadLine()); //8
            /*
             7 19
             7 21
             7 14
             19 1
             19 12
             19 31
             14 23
             14 6
             */
            for (int i = 0; i < nodes; i++)
            {
                int[] edge = Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                Tree<int> parentNode = GetTreeNodeByValue(edge[0]);
                Tree<int> childNode = GetTreeNodeByValue(edge[1]);
                parentNode.AddChild(childNode);
                childNode.Parent = parentNode;
            }

            var rootNode = FindRootNode();
            FindLeafNodes(rootNode);

            Console.WriteLine("Root node: {0}", rootNode.Value);
            
            Console.WriteLine("Leaf nodes: " + FormatIEnumerableTree(leafs));

            Console.WriteLine("Middle nodes: " + FormatIEnumerableTree(FindMiddleNodes()));

            Console.WriteLine("Longest path: " + FormatIEnumerableTree(longestPath) + string.Format(" (length = {0})", currentLongestPath));

            pathTargetSum = int.Parse(Console.ReadLine());  //27
            int subtreeSum = int.Parse(Console.ReadLine()); //43

            TraverseTreeToFindSum(0, FindRootNode());
        }

        private static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }

            return nodeByValue[value];
        }

        private static Tree<int> FindRootNode()
        {
            var rootNode = nodeByValue.Values.FirstOrDefault(node => node.Parent != null);
            return rootNode;
        }

        private static IEnumerable<Tree<int>> FindMiddleNodes()
        {
            var rootNode = FindRootNode();
            var middleNodes = rootNode.Children.Where(node => node.Children.Count > 0);
            return middleNodes;
        }

        private static void TraverseTreeToFindSum(int currentSum, Tree<int> node)
        {
            if (node.Children == null)
            {
                if (currentSum == pathTargetSum)
                {
                    PrintCurrentPath();
                }
                else if ((currentSum += node.Value) == pathTargetSum)
                {
                    pathHelper.Push(node);
                    PrintCurrentPath();
                    pathHelper.Pop();
                }

                return;
            }

            pathHelper.Push(node);
            currentSum += node.Value;

            foreach (Tree<int> childNodes in node.Children)
            {
                TraverseTreeToFindSum(currentSum, childNodes);
            }

            pathHelper.Pop();
        }

        private static void FindLeafNodes(Tree<int> node)
        {
            if (node.Children == null)
            {
                leafs.Add(node);
                return;
            }

            foreach (Tree<int> child in node.Children)
            {
                FindLeafNodes(child);
            }
        }

        private static void SearchForLongestPath(Tree<int> node)
        {
            longestPathHelper.Push(node);
            if (longestPathHelper.Count > currentLongestPath)
            {
                currentLongestPath = longestPathHelper.Count;
                longestPath.Clear();
                foreach (Tree<int> childNode in longestPathHelper)
                {
                    longestPath.Push(childNode);
                }
            }

            if (node.Children != null)
            {
                foreach (Tree<int> childrenNodes in node.Children)
                {
                    SearchForLongestPath(childrenNodes);
                }
            }
            longestPathHelper.Pop();
        }

        private static void PrintCurrentPath()
        {
            List<int> nodeValues = new List<int>();
            foreach (Tree<int> node in pathHelper)
            {
                nodeValues.Add(node.Value);
            }

            nodeValues.Reverse();
            Console.WriteLine(string.Join(" -> ", nodeValues));
        }

        private static string FormatIEnumerableTree(IEnumerable<Tree<int>> nodeCollection)
        {
            var list = nodeCollection.Select(node => node.Value).ToList();
            return string.Join(", ", list);
        }

    }
}