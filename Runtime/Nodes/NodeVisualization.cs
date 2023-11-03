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

        private Node<Vector3> _node;
        private NodeRefresher _nodeRefresher;
        
        [SerializeField]
        private List<NodeVisualization> connections = new ();

        public void Initialize(Node<Vector3> node, NodeRefresher nodeRefresher)
        {
            _node = node;
            _nodeRefresher = nodeRefresher;
        }

        private void OnDrawGizmos()
        {
            RefreshNode();
            
            Gizmos.color = _nodeColor;
            Gizmos.DrawSphere(_node.Value, SphereRadius);
            
            Gizmos.color = _connectionColor;
            _node.Connections.ForEach(connection => Gizmos.DrawLine(transform.position, connection.Value));
        }

        private void OnDrawGizmosSelected()
        {   
            RefreshNode();
            
            Gizmos.color = _nodeSelectedColor;
            Gizmos.DrawSphere( _node.Value, SphereRadius);
            
            Gizmos.color = _connectionSelectedColor;
            _node.Connections.ForEach(connection => Gizmos.DrawLine(transform.position, connection.Value));
        }

        private void RefreshNode()
        {
            CleanUpConnections();
            _nodeRefresher.RefreshPosition(_node, this);
            
            if (_node.Connections.Count > connections.Count)
            {
                _nodeRefresher.RefreshConnectionsFromNode(_node, this);
            }
            
            _nodeRefresher.RefreshConnectionsToNode(_node, connections);
        }
        
        private void CleanUpConnections() 
            => connections.Where(connection => connection == null).ToList()
                .ForEach(connection => connections.Remove(connection));

        public void AddConnections(IEnumerable<NodeVisualization> nodeVisualization)
        {
            connections.Clear();
            connections.AddRange(nodeVisualization);
        }
            
    }
}