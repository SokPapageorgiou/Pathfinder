using System.Collections.Generic;
using System.Linq;
using Nodes;
using UnityEngine;

namespace Graph
{
    public class GraphGenerator
    {
        public List<Node<Vector3>> Generate(Vector3 size)
        {
            var nodes = GenerateList(size);
            nodes.ForEach(node => SetDefaultConnections(node, nodes));
            
            return nodes;
        }

        private List<Node<Vector3>> GenerateList(Vector3 size)
        {
            var nodes = new List<Node<Vector3>>();
            
            var nodesToAdd = 
                from i in Enumerable.Range(0, (int)size.z)
                from j in Enumerable.Range(0, (int)size.y)
                from k in Enumerable.Range(0, (int)size.x)
                let nodePosition = new Vector3(k, j, i)
                let node = new Node<Vector3>(nodePosition, new List<Node<Vector3>>())
                select node;

            nodes.AddRange(nodesToAdd);
            
            return nodes;
        }

        private void SetDefaultConnections(Node<Vector3> targetNode, IReadOnlyCollection<Node<Vector3>> nodes)
        {
            List<Node<Vector3>> possibleConnections = new List<Node<Vector3>>
            {
                GetFromPosition(targetNode.Value + Vector3.right, nodes),
                GetFromPosition(targetNode.Value + Vector3.up, nodes),
                GetFromPosition(targetNode.Value + Vector3.forward, nodes)
            };

            possibleConnections.ForEach(node => AddMutualConnection(targetNode, node));
        }
        
        private void AddMutualConnection(Node<Vector3> nodeA, Node<Vector3> nodeB)
        {
            if(nodeA == null || nodeB == null) return;
            
            nodeA.Connections.Add(nodeB);
            nodeB.Connections.Add(nodeA);
        }
        
        private Node<Vector3> GetFromPosition(Vector3 position, IEnumerable<Node<Vector3>> nodes) 
            => nodes.FirstOrDefault(node => node.Value == position);
    }
}