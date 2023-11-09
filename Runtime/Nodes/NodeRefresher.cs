using System.Collections.Generic;
using System.Linq;
using Graph;
using UnityEngine;

namespace Nodes
{
    public class NodeRefresher
    {
        private readonly GraphContainer _graphContainer;

        public NodeRefresher(GraphContainer graphContainer)
        {
            _graphContainer = graphContainer;
        }

        public static void RefreshPosition(Node node, NodeVisualization nodeVisualization)
        {
            if(node.Position == nodeVisualization.transform.position) return;
            
            node.Position = nodeVisualization.transform.position;
        }

        public void RefreshConnectionsFromNode(Node node, NodeVisualization nodeVisualization)
            => nodeVisualization.AddConnections(_graphContainer.Nodes.FirstOrDefault(item => item == node)?.Connections);

        public void RefreshConnectionsToNode(Node node, List<NodeVisualization> connections)
        {
            var equalCount = connections.Count == node.Connections.Count;
            var equalConnections = connections.All(connection => node.Connections
                .Any(nodeConnection => nodeConnection.Value.Position == connection.transform.position));
            
            if(equalCount && equalConnections) return;
            
            node.Connections.Clear();

            node.Connections.AddRange(connections
                .Select(nodeVisualization => new NodeConnection(_graphContainer.Nodes
                    .FirstOrDefault(item => item.Visualization == nodeVisualization))));
        }
    }
}