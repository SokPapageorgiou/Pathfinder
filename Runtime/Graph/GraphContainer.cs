using System.Collections.Generic;
using Nodes;
using UnityEngine;

namespace Graph
{
    public class GraphContainer : MonoBehaviour
    {
        public Dictionary<Node<Vector3>, NodeVisualization> Nodes { get; } = new();
        
        public void AddNode(Node<Vector3> node, NodeVisualization nodeVisualization)
        {
            Nodes.TryAdd(node, nodeVisualization);
        }
    }
}