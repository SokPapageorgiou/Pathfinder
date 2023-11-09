using Nodes;
using UnityEngine;

namespace Heuristics
{
    public class PositionHeuristic 
    {
        private readonly Node _goalNode;
        
        public PositionHeuristic(Node goalNode)
        {
            _goalNode = goalNode;
        }

        public float Estimate(Node node) 
            => Distance(node.Position, _goalNode.Position);

        public float Estimate(Node fromNode, Node toNode) 
            => Distance(fromNode.Position, toNode.Position);
        
        private static float Distance(Vector3 from, Vector3 to)
            => Vector3.Distance(from, to);
    }
}