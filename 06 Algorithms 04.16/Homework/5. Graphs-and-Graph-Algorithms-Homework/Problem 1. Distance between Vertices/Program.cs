namespace Problem_1.Distance_between_Vertices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

        private static HashSet<int> visited; 

        static void Main(string[] args)
        {
            /*
            Graph:
            1 -> 4
            2 -> 4
            3 -> 4, 5
            4 -> 6
            5 -> 3, 7, 8
            6 ->
            7 -> 8
            8 ->
            Distances to find:
            1-6
            1-5
            5-6
            5-8        
             */
            var token = Console.ReadLine();
            ReadGraph();
            while (true)
            {
                var vertices = Console.ReadLine().Split('-').Select(int.Parse).ToArray();
                visited = new HashSet<int>();
                var queue = new Queue<int>();
                int distance = int.MaxValue;
                FindShortestDistance(queue, vertices[0], vertices[1], ref distance);

                string message = string.Empty;
                if (distance != int.MaxValue)
                {
                    message = "{" + vertices[0] + ", " + vertices[1] + "} -> " + distance;
                    Console.WriteLine(message);
                }
                else
                {
                    message = "{" + vertices[0] + ", " + vertices[1] + "} -> -1";
                    Console.WriteLine(message);
                }
            }
        }

        private static void ReadGraph()
        {
            var input = Console.ReadLine();

            while (input != "Distances to find:")
            {
                var args = input.Split(new char[] { ' ', '-', '>', ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();

                int startNode = args[0];

                if (!graph.ContainsKey(args[0]))
                {
                    graph[startNode] = new List<int>();
                }

                for (int i = 1; i < args.Count; i++)
                {
                    graph[startNode].Add(args[i]);
                }

                input = Console.ReadLine();
            }
        }

        private static void FindShortestDistance(Queue<int> queue, int startingNode, int targetNode, ref int shortestDistance, int steps = 0)
        {
            if (visited.Contains(startingNode))
            {
                return;
            }

            queue.Enqueue(startingNode);
            visited.Add(startingNode);

            var node = queue.Dequeue();
            if (node == targetNode && steps < shortestDistance)
            {
                shortestDistance = steps;
            }

            foreach (int child in graph[node])
            {
                FindShortestDistance(queue, child, targetNode, ref shortestDistance, steps + 1);
            }

            visited.Remove(startingNode);
        }
    }
}
