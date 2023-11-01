using System.Collections.Generic;
using Nodes;
using UnityEngine;

namespace Graph
{
    public class GraphContainer : MonoBehaviour
    {
        public List<Node<Vector3>> Nodes { get; private set; }

        public void Initialize(List<Node<Vector3>> nodes)
        {
            Nodes = nodes;
        }
    }
}