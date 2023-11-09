using UnityEngine.Serialization;

namespace Nodes
{
    [System.Serializable]
    public struct NodeConnection
    {
        public Node Value;
        public int costToNode;

        public NodeConnection(Node value, int costToNode = 1)
        {
            Value = value;
            this.costToNode = costToNode;
        }
    }
}