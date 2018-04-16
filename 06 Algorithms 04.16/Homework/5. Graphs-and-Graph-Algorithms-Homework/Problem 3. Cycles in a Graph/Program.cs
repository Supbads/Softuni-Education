namespace Problem_3.Cycles_in_a_Graph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    class Program
    {
        private static readonly Dictionary<string, List<string>> graph =
            new Dictionary<string, List<string>>(); 

        //private static readonly HashSet<string> visited = new HashSet<string>();

        private static readonly HashSet<string> cycleNodes = new HashSet<string>(); 

        private static bool isAcyclic = true;

        static void Main(string[] args)
        {
            /*
A - F
F - D
D - A
end
             * 
A - B
end
             * 
E - Q
Q - P
P - B
end
             * 
K - X
X - Y
X - N
N - J
M - N
A - Z
B - P
I - F
A - Y
Y - L
M - I
F - P
Z - E
P - E
end
             * 
            */
            ReadGraph();
            CheckIfGraphIsAcyclic();

            Console.WriteLine(isAcyclic ? "Acyclic: Yes" : "Acyclic: No");
        }

        private static void CheckIfGraphIsAcyclic()
        {
            Dictionary<string, int> predcessorsCount = new Dictionary<string, int>();
            FindPredcessorsCount(predcessorsCount);

            while (true)
            {
                // magic
                string startingNode = graph.Keys.OrderBy(n => predcessorsCount[n]).FirstOrDefault(n => predcessorsCount[n] == 1 || predcessorsCount[n] == 0);

                if (startingNode == null)
                {
                    break;
                }
                
                foreach (var child in graph[startingNode])
                {
                    predcessorsCount[child]--;
                }

                graph.Remove(startingNode);
            }

            if (graph.Count > 0)
            {
                isAcyclic = false;
            }
        }

        private static void ReadGraph()
        {
            string input = Console.ReadLine();
            while (input != "end")
            {
                var args = input.Split(new char[] { ' ', '–', '-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (!graph.ContainsKey(args[0]))
                {
                    graph[args[0]] = new List<string>();
                }

                graph[args[0]].Add(args[1]);

                if (!graph.ContainsKey(args[1]))
                {
                    graph[args[1]] = new List<string>();
                }

                graph[args[1]].Add(args[0]);

                input = Console.ReadLine();
            }
        }
        private static void FindPredcessorsCount(Dictionary<string, int> predcessorsCount)
        {
            foreach (var node in graph)
            {
                
                if (!predcessorsCount.ContainsKey(node.Key))
                {
                    predcessorsCount[node.Key] = 0;
                }

                foreach (var child in node.Value)
                {
                    if (!predcessorsCount.ContainsKey(child))
                    {
                        predcessorsCount[child] = 0;
                    }

                    predcessorsCount[child] += 1;
                }
            }
        }
    }
}
