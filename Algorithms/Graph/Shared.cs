using System;
using System.Collections.Generic;
using System.IO;

namespace Algorithms.Graph
{
    public partial class Graphs
    {
        public class Node
        {
            public int Id { get; set; }
            public bool Explored { get; set; }
            public List<int> Edges { get; set; }
            public int Parent { get; set; }
            public int Distance { get; set; }
        }

        public class NodeWeighted
        {
            public int Id { get; set; }
            public HashSet<int> ShortestPath { get; set; }
            public double Distance { get; set; }
            public Dictionary<int, double> AdjacentNodes { get; set; }

            public NodeWeighted(int id)
            {
                Id = id;
                Distance = int.MaxValue;
                AdjacentNodes = new Dictionary<int, double>();
                ShortestPath = new HashSet<int>();
            }

            public void AddNeighbor(int id, double weight)
            {
                AdjacentNodes.Add(id, weight);
            }
        }

        public static Dictionary<int, NodeWeighted> CreatedWeightedGraphFromDelimitedFile(string fileName, char delimeter, char delimeter2 = ',')
        {
            var result = new Dictionary<int, NodeWeighted>();
            StreamReader reader = new StreamReader(fileName);

            int rowCount = 1;

            while (reader.Peek() > 0)
            {
                var rowData = reader.ReadLine().Split(delimeter);

                try
                {
                    var nodeId = Convert.ToInt32(rowData[0]);
                    var node = new NodeWeighted(nodeId);

                    for (int i = 1; i < rowData.Length; i++)
                    {
                        if (!String.IsNullOrWhiteSpace(rowData[i]))
                        {
                            var edgeData = rowData[i].Split(delimeter2);
                            if (!String.IsNullOrWhiteSpace(edgeData[0]) && !String.IsNullOrWhiteSpace(edgeData[1]))
                            {
                                int neighbor = Convert.ToInt32(edgeData[0]);
                                double weight = Convert.ToDouble(edgeData[1]);
                                node.AddNeighbor(neighbor, weight);                               
                            }
                        }                     
                    }

                    result.Add(nodeId, node);
                    rowCount++;

                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error parsing row {0}", rowCount);
                }
            }
            return result;
        }

        public static Dictionary<int, List<int>> CreateUnweightedGraphFromDelimitedFile(string fileName, char delimeter)
        {
            var result = new Dictionary<int, List<int>>();
            StreamReader reader = new StreamReader(fileName);

            int rowCount = 1;

            while (reader.Peek() > 0)
            {
                var rowData = reader.ReadLine().Split(delimeter);

                try
                {
                    var rowKey = Convert.ToInt32(rowData[0]);
                    var rowValues = new List<int>();

                    for (int i = 1; i < rowData.Length; i++)
                    {
                        if (!String.IsNullOrWhiteSpace(rowData[i]))
                            rowValues.Add(Convert.ToInt32(rowData[i]));
                    }

                    if (result.ContainsKey(rowKey))
                    {
                        result[rowKey].AddRange(rowValues);
                    }
                    else
                    {
                        result.Add(rowKey, rowValues);
                    }

                    rowCount++;
                    
                }
                catch
                {
                    Console.WriteLine("Error parsing row {0}", rowCount);
                }
            }

            return result;
        }

        public static Dictionary<int, Node> GetNodesWithProperties(Dictionary<int, List<int>> graph)
        {
            var nodes = new Dictionary<int, Node>();

            foreach (var node in graph)
            {
                var nodeWithProperties = new Node { Id = node.Key, Explored = false, Edges = node.Value };
                nodes.Add(node.Key, nodeWithProperties);
            }

            return nodes;
        }

        public static Dictionary<int, List<int>> ReverseGraph(Dictionary<int, List<int>> graph)
        {
            var reversed = new Dictionary<int, List<int>>();

            foreach (var node in graph)
            {
                foreach (var edge in node.Value)
                {
                    if (!reversed.ContainsKey(edge))
                        reversed.Add(edge, new List<int>());

                    reversed[edge].Add(node.Key);
                }
            }

            return reversed;
        }

        public static int GetNumberOfEdges(Dictionary<int, List<int>> adjacentList, List<int> nodes)
        {
            int m = 0;

            for (int i = 0; i < nodes.Count; i++)
            {
                List<int> vector = adjacentList[nodes[i]];
                m += vector.Count;
            }

            return m;
        }

        public static int[,] GetEdges(int m, Dictionary<int, List<int>> adjacentList, List<int> nodes)
        {
            int k = 0;
            int[,] edges = new int[m, 2];

            for (var i = 0; i < nodes.Count; i++)
            {
                List<int> vector = adjacentList[nodes[i]];

                for (var j = 0; j < vector.Count; j++)
                {
                    edges[k, 0] = nodes[i];
                    edges[k, 1] = vector[j];
                    k++;
                }
            }

            return edges;
        }

        public static List<int> GetNodes(Dictionary<int, List<int>> graph)
        {
            var nodes = new List<int>();

            foreach (var node in graph)
            {
                nodes.Add(node.Key);
            }

            return nodes;
        }
  
    }
}
