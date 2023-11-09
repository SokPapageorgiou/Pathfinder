using Nodes;

namespace Heuristics
{
    public abstract class Heuristic<T>
    {
        protected readonly Node GoalNode;

        protected Heuristic(Node goalNode)
        {
            GoalNode = goalNode;
        }
        
        public abstract float Estimate(Node fromNode);
        
        public abstract float Estimate(Node fromNode, Node toNode);
    }
}