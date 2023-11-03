using System.Collections.Generic;
using System.Linq;
using Graph;
using Nodes;
using UnityEngine;

namespace Editor.Graph
{
    public class GraphInstantiator
    {
        private NodeRefresher _nodeRefresher;
        
        public void Instantiate(string name, List<Node<Vector3>> nodes, float scale)
        {
            var parent = new GameObject(name);
            var graphContainer = parent.AddComponent<GraphContainer>();
            _nodeRefresher = new NodeRefresher(graphContainer);
            
            nodes.ForEach(node => InstantiateNode(node, graphContainer, scale));
            
            graphContainer.Nodes.Keys.ToList()
                .ForEach(node => _nodeRefresher.RefreshConnectionsFromNode(node, graphContainer.Nodes[node]));
        }

        public void InstantiateNode(Node<Vector3> node, GraphContainer parent, float scale = 1f)
        {
            var instance = new GameObject("Node");
            instance.transform.SetParent(parent.transform);
            instance.transform.position = node.Value * scale;
            
            var nodeVisualization = instance.AddComponent<NodeVisualization>();
            nodeVisualization.Initialize(node, _nodeRefresher);
            
            parent.AddNode(node, nodeVisualization);
        }
    }
}