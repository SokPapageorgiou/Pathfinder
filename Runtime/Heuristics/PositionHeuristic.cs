using Nodes;
using UnityEngine;

namespace Heuristics
{
    public class PositionHeuristic : Heuristic<Vector3>
    {
        public PositionHeuristic(Node<Vector3> goalNode) : base(goalNode)
        {
        }

        public override float Estimate(Node<Vector3> node) 
            => Distance(node.Value, GoalNode.Value);

        public override float Estimate(Node<Vector3> fromNode, Node<Vector3> toNode) 
            => Distance(fromNode.Value, toNode.Value);
        
        private static float Distance(Vector3 from, Vector3 to)
            => Vector3.Distance(from, to);
    }
}