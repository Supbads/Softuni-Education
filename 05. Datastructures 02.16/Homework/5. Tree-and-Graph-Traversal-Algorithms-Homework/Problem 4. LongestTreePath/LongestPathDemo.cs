namespace _04.LongestTreePath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestPathDemo
    {
        private static Dictionary<int, List<int>> tree = new Dictionary<int, List<int>>();
        private static Dictionary<int, int?> parents = new Dictionary<int, int?>();
        private static List<int> rootsSum = new List<int>();

        public static void Main()
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            for (int i = 0; i < edges; i++)
            {
                var input = Console.ReadLine().Split(' ');

                int node = int.Parse(input[0]);
                int leaf = int.Parse(input[1]);

                if (!tree.ContainsKey(node))
                {
                    tree.Add(node, new List<int>());
                }

                if (!parents.ContainsKey(leaf))
                {
                    parents[leaf] = node;
                }

                if (!parents.ContainsKey(node))
                {
                    parents[node] = null;
                }

                tree[node].Add(leaf);
                parents[leaf] = node;
            }

            int root = FindRoot();
            var pathsSums = new List<int>();

            foreach (var node in tree[root])
            {
                DFS(0, node);
                pathsSums.Add(rootsSum.Max());
                rootsSum.Clear();
            }

            Console.WriteLine(pathsSums.Sum() + root);

            Console.WriteLine("done");
        }

        private static int FindRoot()
        {
            var root = parents.First(p => p.Value == null);
            return root.Key;
        }

        private static void DFS(int max, int root)
        {
            max += root;
            if (tree.ContainsKey(root))
            {
                foreach (var node in tree[root])
                {
                    DFS(max, node);
                }
            }
            else
            {
                rootsSum.Add(max);
            }
        }
    }
}
