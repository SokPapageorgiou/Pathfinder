using System.Collections.Generic;
using System.Linq;
using Nodes;
using UnityEngine;

namespace Graph
{
    public class GraphContainer : MonoBehaviour
    {
        public Dictionary<Node<Vector3>, NodeVisualization> Nodes { get; } = new();
        
        public void AddNode(Node<Vector3> node, NodeVisualization nodeVisualization)
            => Nodes.TryAdd(node, nodeVisualization);
        
        private void OnDrawGizmos() => CleanUpEmptyValues();
        
        private void CleanUpEmptyValues() 
            => Nodes.Where(node => node.Value == null).ToList()
                .ForEach(empty => Nodes.Remove(empty.Key));
    }
}