using System.Collections.Generic;
using System.Linq;
using Nodes;
using UnityEngine;

namespace Graph
{
    public class GraphGenerator
    {
        public static List<Node> Generate(Vector3 size)
        {
            var nodes = GenerateList(size);
            nodes.ForEach(node => SetDefaultConnections(node, nodes));
            
            return nodes;
        }

        private static List<Node> GenerateList(Vector3 size)
        {
            var nodes = new List<Node>();

            var nodesToAdd =
                from i in Enumerable.Range(0, (int)size.z)
                from j in Enumerable.Range(0, (int)size.y)
                from k in Enumerable.Range(0, (int)size.x)
                let nodePosition = new Vector3(k, j, i)
                let node = new Node(nodePosition)
                select node;

            nodes.AddRange(nodesToAdd);
            
            return nodes;
        }

        private static void SetDefaultConnections(Node targetNode, IReadOnlyCollection<Node> nodes)
        {
            var possibleConnections = new List<Node>
            {
                GetFromPosition(targetNode.Position + Vector3.right, nodes),
                GetFromPosition(targetNode.Position + Vector3.up, nodes),
                GetFromPosition(targetNode.Position + Vector3.forward, nodes)
            };

            possibleConnections.ForEach(node => AddMutualConnection(targetNode, node));
        }
        
        private static void AddMutualConnection(Node nodeA, Node nodeB)
        {
            if(nodeA == null || nodeB == null) return;
            
            nodeA.Connections.Add(new NodeConnection(nodeB));
            nodeB.Connections.Add(new NodeConnection(nodeA));
        }
        
        private static Node GetFromPosition(Vector3 position, IEnumerable<Node> nodes) 
            => nodes.FirstOrDefault(node => node.Position == position);
    }
}