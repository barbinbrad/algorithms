using System;
using System.Collections.Generic;

namespace Algorithms.Graph
{
    public partial class Graphs
    {
        public static void DijkstrasShortestPath(ref Dictionary<int, NodeWeighted> graph, int source)
        {
            if (!graph.ContainsKey(source)) return;

            graph[source].Distance = 0;

            var known = new HashSet<NodeWeighted>();
            var unknown = new HashSet<NodeWeighted>();

            unknown.Add(graph[source]);

            while (unknown.Count > 0)
            {
                NodeWeighted currentNode = GetClosestNodeFrom(unknown);
                unknown.Remove(currentNode);

                foreach(var node in currentNode.AdjacentNodes)
                {
                    NodeWeighted adjacentNode = graph[node.Key];
                    var edgeWeight = node.Value;

                    if (!known.Contains(adjacentNode))
                    {
                        UpdateMinimumDistance(ref graph, adjacentNode, edgeWeight, currentNode);
                        unknown.Add(adjacentNode);
                    }
                }

                known.Add(currentNode);
            }

        }



        private static NodeWeighted GetClosestNodeFrom(HashSet<NodeWeighted> nodes)
        {
            NodeWeighted closest = null;

            var lowestDistance = double.MaxValue;

            foreach(var node in nodes)
            {
                double distance = node.Distance;
                if(distance < lowestDistance)
                {
                    closest = node;
                    lowestDistance = distance;
                }
            }

            return closest;
        }

        private static void UpdateMinimumDistance(ref Dictionary<int, NodeWeighted> graph, NodeWeighted currentNode, double edgeWeight, NodeWeighted sourceNode)
        {
            double sourceDistance = sourceNode.Distance;

            if(sourceDistance + edgeWeight < currentNode.Distance)
            {
                currentNode.Distance = sourceDistance + edgeWeight;
                var shortestPath = sourceNode.ShortestPath;
                shortestPath.Add(sourceNode.Id);
                currentNode.ShortestPath = new HashSet<int>(shortestPath);
            }
        }

        public static void LogDijkstraPath(Dictionary<int, NodeWeighted> graph, int target)
        {
            Console.WriteLine("The shortest path to node {0} is: ", target);
            bool firstStep = true;
            foreach(var step in graph[target].ShortestPath)
            {
                if (firstStep)
                {
                    Console.Write(step);
                    firstStep = false;
                }
                else
                {
                    Console.Write("," + step);
                }
            }
            
            Console.WriteLine("");
            Console.WriteLine("The distance is: {0}", graph[target].Distance);
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}
