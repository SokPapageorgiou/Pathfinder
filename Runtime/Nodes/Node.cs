using System.Collections.Generic;

namespace Nodes
{
    public class Node<T>
    {
        public T Value { get; set; }
        public List<Node<T>> Connections { get; private set; }

        public Node(T value, List<Node<T>> connections)
        {
            Value = value;
            Connections = connections;
        }
    }
}
