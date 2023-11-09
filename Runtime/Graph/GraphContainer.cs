using System.Collections.Generic;
using System.Linq;
using Nodes;
using UnityEngine;

namespace Graph
{
    public class GraphContainer : MonoBehaviour
    {
        public List<Node> Nodes { get; } = new();
        
        public void AddNode(Node node)
            => Nodes.Add(node);
        
        private void OnDrawGizmos() => CleanUpEmptyValues();
        
        private void CleanUpEmptyValues() 
            => Nodes.Where(node => node == null).ToList()
                .ForEach(empty => Nodes.Remove(empty));
    }
}