using System.Collections.Generic;
using System.Linq;
using Graph;
using Nodes;
using UnityEngine;

namespace Editor.Graph
{
    public class GraphInstantiator
    {
        public void Instantiate(string name, List<Node<Vector3>> nodes, float scale)
        {
            var parent = new GameObject(name);
            var graphContainer = parent.AddComponent<GraphContainer>();
            
            nodes.ForEach(node => InstantiateNode(node, graphContainer, scale));
        }

        private void InstantiateNode(Node<Vector3> node, GraphContainer parent, float scale)
        {
            var instance = new GameObject("Node");
            instance.transform.SetParent(parent.transform);
            instance.transform.position = node.Value * scale;
            
            var nodeVisualization = instance.AddComponent<NodeVisualization>();
            nodeVisualization.Initialize(node, parent);
            
            parent.AddNode(node, nodeVisualization);
        }
    }
}