using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Nodes
{
    public class NodeVisualization : MonoBehaviour
    {
        private readonly Color _nodeColor = Color.gray;
        private readonly Color _nodeSelectedColor = Color.yellow;
        private readonly Color _connectionColor = Color.blue;
        private readonly Color _connectionSelectedColor = Color.magenta;
        
        private const float SphereRadius = 0.5f;

        private Node _node;
        private NodeRefresher _nodeRefresher;
        
        [SerializeField]
        private List<NodeConnection> connections = new ();

        public void Initialize(Node node, NodeRefresher nodeRefresher)
        {
            _node = node;
            _nodeRefresher = nodeRefresher;
        }

        private void OnDrawGizmos()
        {
            RefreshNode();
            
            Gizmos.color = _nodeColor;
            Gizmos.DrawSphere(_node.Position, SphereRadius);
            
            Gizmos.color = _connectionColor;
            _node.Connections.ForEach(connection => Gizmos.DrawLine(transform.position, connection.Value.Position));
        }

        private void OnDrawGizmosSelected()
        {   
            RefreshNode();
            
            Gizmos.color = _nodeSelectedColor;
            Gizmos.DrawSphere( _node.Position, SphereRadius);
            
            Gizmos.color = _connectionSelectedColor;
            _node.Connections.ForEach(connection => Gizmos.DrawLine(transform.position, connection.Value.Position));
        }

        private void RefreshNode()
        {
            if(connections.Count == 0) 
            {
                _nodeRefresher.RefreshConnectionsFromNode(_node, this);
            }
            else
            {
                CleanUpConnections();
                NodeRefresher.RefreshPosition(_node, this);
                _nodeRefresher.RefreshConnectionsToNode(_node, connections
                    .Select(connection => connection.Value.Visualization).ToList());  
            }
        }
        
        private void CleanUpConnections() 
            => connections.Where(connection => connection.Value == null).ToList()
                .ForEach(connection => connections.Remove(connection));

        public void AddConnections(IEnumerable<NodeConnection> nodeVisualization)
        {
            connections.Clear();
            connections.AddRange(nodeVisualization);
        }
            
    }
}