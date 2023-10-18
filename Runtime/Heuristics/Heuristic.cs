using Nodes;

namespace Heuristics
{
    public abstract class Heuristic<T>
    {
        private Node<T> _goalNode;

        protected Heuristic(Node<T> goalNode)
        {
            _goalNode = goalNode;
        }
        
        public abstract float Estimate(Node<T> node);
        
        public abstract float Estimate(Node<T> fromNode, Node<T> toNode);
    }
}