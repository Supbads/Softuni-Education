namespace DistanceBetweenVertices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DistanceBetweenVertices
    {
        public static void Main(string[] args)
        {
            var graph = new Dictionary<int, List<int>>();
            Console.ReadLine();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Distances to find:")
                {
                    break;
                }

                string[] input = command.Split(new[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                int node = int.Parse(input[0].Trim());
                graph[node] = new List<int>();
                if (input.Length > 1)
                {
                    int[] children = input[1].Trim().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    foreach (var child in children)
                    {
                        graph[node].Add(child);
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(command))
                {
                    return;
                }

                int[] arguments = command.Split(new[] {'-'}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int startNode = arguments[0];
                if (!graph.ContainsKey(startNode))
                {
                    continue;
                }

                int endNode = arguments[1];
                bool pathFound = false;
                HashSet<int> visited = new HashSet<int>();
                Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
                queue.Enqueue(new Tuple<int, int>(startNode, 0));

                while (queue.Count > 0)
                {
                    Tuple<int, int> current = queue.Dequeue();
                    if (visited.Contains(current.Item1))
                    {
                        continue;
                    }
                    visited.Add(current.Item1);
                    if (current.Item1 == endNode)
                    {
                        pathFound = true;
                        Console.WriteLine(string.Format("{{{0}, {1}}} -> {2}", startNode, endNode, current.Item2));
                        break;
                    }
                    foreach (var child in graph[current.Item1])
                    {
                        queue.Enqueue(new Tuple<int, int>(child, current.Item2 + 1));
                    }
                }
                if (!pathFound)
                {
                    Console.WriteLine("{{{0}, {1}}} -> -1", startNode, endNode);
                }
            }
        }
    }
}
