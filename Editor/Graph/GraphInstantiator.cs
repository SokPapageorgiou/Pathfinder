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
        
        public void Instantiate(string name, List<Node> nodes, float scale)
        {
            var parent = new GameObject(name);
            var graphContainer = parent.AddComponent<GraphContainer>();
            _nodeRefresher = new NodeRefresher(graphContainer);
            
            nodes.ForEach(node => InstantiateNode(node, graphContainer, scale));
            
            graphContainer.Nodes
                .ForEach(node => _nodeRefresher.RefreshConnectionsFromNode
                    (node, graphContainer.Nodes.Find(item => item == node).Visualization));
        }

        public void InstantiateNode(Node node, GraphContainer parent, float scale = 1f)
        {
            var instance = new GameObject($"Node_{parent.Nodes.Count}");
            instance.transform.SetParent(parent.transform);
            instance.transform.position = node.Position * scale;
            
            var nodeVisualization = instance.AddComponent<NodeVisualization>();
            node.SetVisualization(nodeVisualization);
            nodeVisualization.Initialize(node, _nodeRefresher);
            
            parent.AddNode(node);
        }
    }
}