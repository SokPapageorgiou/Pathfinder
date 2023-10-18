using Nodes;

namespace Heuristics
{
    public abstract class Heuristic<T>
    {
        protected readonly Node<T> GoalNode;

        protected Heuristic(Node<T> goalNode)
        {
            GoalNode = goalNode;
        }
        
        public abstract float Estimate(Node<T> fromNode);
        
        public abstract float Estimate(Node<T> fromNode, Node<T> toNode);
    }
}