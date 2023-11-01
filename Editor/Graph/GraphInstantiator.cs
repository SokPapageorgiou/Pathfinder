using System.Collections.Generic;
using Graph;
using Nodes;
using UnityEngine;

namespace Editor.Graph
{
    public class GraphInstantiator
    {
        public void Instantiate(string name, List<Node<Vector3>> nodes)
        {
            var parent = new GameObject(name);
            parent.AddComponent<GraphContainer>();
        }
    }
}