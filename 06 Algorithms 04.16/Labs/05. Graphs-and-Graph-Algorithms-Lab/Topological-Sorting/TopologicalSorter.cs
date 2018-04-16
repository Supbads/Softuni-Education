using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;
    private HashSet<string> visitedNodes;
    private HashSet<string> cycleNodes; 
    private LinkedList<string> sortedNodes; 

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
    }

    public ICollection<string> TopSort()
    {
        //var removedNodes = new List<string>();
        //this.TopSortRemoval(removedNodes);

        this.visitedNodes = new HashSet<string>();
        this.sortedNodes = new LinkedList<string>();
        this.cycleNodes = new HashSet<string>();

        foreach (string node in this.graph.Keys)
        {
            this.DFSTopSort(node);
        }

        return this.sortedNodes;
    }

    private void DFSTopSort(string node)
    {
        if (this.cycleNodes.Contains(node))
        {
            throw new InvalidOperationException("A cycle has been detected in the graph");
        }
        
        if (this.visitedNodes.Contains(node))
        {
            return;
        }

        this.cycleNodes.Add(node);
        this.visitedNodes.Add(node);

        if (this.graph.ContainsKey(node))
        {
            foreach (string child in this.graph[node])
            {
                this.DFSTopSort(child);
            }
        }

        this.cycleNodes.Remove(node);
        this.sortedNodes.AddFirst(node);
    }

    private void FindPredcessorsCount(Dictionary<string, int> predcessorsCount)
    {
        foreach (var node in this.graph)
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

    private void TopSortRemoval(ICollection<string> removedNodes)
    {
        Dictionary<string, int> predcessorsCount = new Dictionary<string, int>();
        this.FindPredcessorsCount(predcessorsCount);

        while (true)
        {
            string startingNode = this.graph.Keys.FirstOrDefault(n => predcessorsCount[n] == 0);

            if (startingNode == null)
            {
                break;
            }

            removedNodes.Add(startingNode);

            foreach (var child in this.graph[startingNode])
            {
                predcessorsCount[child]--;
            }

            this.graph.Remove(startingNode);
        }

        if (this.graph.Count > 0)
        {
            throw new InvalidOperationException("A Cycle detected in the graph");
        }
    }
}
