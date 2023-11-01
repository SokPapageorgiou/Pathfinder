﻿using Nodes;
using UnityEngine;

namespace Editor.Nodes
{
    public class NodeVisualization : MonoBehaviour
    {
        private readonly Color _nodeColor = Color.gray;
        private readonly Color _nodeSelectedColor = Color.yellow;
        private readonly Color _connectionColor = Color.blue;
        private readonly Color _connectionSelectedColor = Color.magenta;
        
        private const float SphereRadius = 0.5f;

        private Node<Vector3> _node;

        public void Initialize(Node<Vector3> node)
        {
            _node = node;
        }
        
        private void OnDrawGizmos()
        {
            _node.Value = transform.position;
            
            Gizmos.color = _nodeColor;
            Gizmos.DrawSphere(_node.Value, SphereRadius);
            
            Gizmos.color = _connectionColor;
            _node.Connections.ForEach(connection => Gizmos.DrawLine(transform.position, connection.Value));
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = _nodeSelectedColor;
            Gizmos.DrawSphere(transform.position, SphereRadius);
            
            Gizmos.color = _connectionSelectedColor;
            _node.Connections.ForEach(connection => Gizmos.DrawLine(transform.position, connection.Value));
        }
    }
}