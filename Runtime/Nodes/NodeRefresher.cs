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

        public void RefreshPosition(Node<Vector3>node, NodeVisualization nodeVisualization) 
            => node.Value = nodeVisualization.transform.position;
        
        public void RefreshConnectionsFromNode(Node<Vector3>node, NodeVisualization nodeVisualization) 
            => nodeVisualization.AddConnections( node.Connections
                .Select(nodeConnection => _graphContainer.Nodes[nodeConnection]).ToList());

        public void RefreshConnectionsToNode(Node<Vector3> node, List<NodeVisualization> connections)
        {
            var equalCount = connections.Count == node.Connections.Count;
            var equalConnections = connections.All(connection => node.Connections
                .Any(nodeConnection => nodeConnection.Value == connection.transform.position));
            
            if(equalCount && equalConnections) return;
            
            node.Connections.Clear();
            
            connections.ForEach(connection => node.Connections
                .Add(_graphContainer.Nodes.First(pair => pair.Value == connection).Key));
        }
    }
}