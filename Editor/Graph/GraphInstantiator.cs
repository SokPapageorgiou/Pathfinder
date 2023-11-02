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
            var nodeRefresher = new NodeRefresher(graphContainer);
            
            nodes.ForEach(node => InstantiateNode(node, graphContainer, scale, nodeRefresher));
            
            graphContainer.Nodes.Keys.ToList()
                .ForEach(node => nodeRefresher.RefreshConnectionsFromNode(node, graphContainer.Nodes[node]));
        }

        private void InstantiateNode(Node<Vector3> node, GraphContainer parent, float scale, 
            NodeRefresher nodeRefresher)
        {
            var instance = new GameObject("Node");
            instance.transform.SetParent(parent.transform);
            instance.transform.position = node.Value * scale;
            
            var nodeVisualization = instance.AddComponent<NodeVisualization>();
            nodeVisualization.Initialize(node, nodeRefresher);
            
            parent.AddNode(node, nodeVisualization);
        }
    }
}