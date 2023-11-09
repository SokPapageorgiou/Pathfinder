using System.Collections.Generic;
using UnityEngine;

namespace Nodes
{
    public class Node
    {
        public Vector3 Position { get; set; }
        public NodeVisualization Visualization { get; private set; }
        public List<NodeConnection> Connections { get; set; } = new();

        public Node(Vector3 position)
        {
            Position = position;
        }
        
        public void SetVisualization(NodeVisualization visualization) => Visualization = visualization;
        
    }
}
