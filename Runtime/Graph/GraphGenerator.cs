using System.Collections.Generic;
using System.Linq;
using Heuristics;
using Nodes;
using UnityEngine;

namespace Graph
{
    public class GraphGenerator
    {
        public List<Node<Vector3>> Generate(Vector3 size)
        {
            var nodes = new List<Node<Vector3>>();
            
            var nodesToAdd = 
                from i in Enumerable.Range(0, (int)size.z)
                from j in Enumerable.Range(0, (int)size.y)
                from k in Enumerable.Range(0, (int)size.x)
                let nodePosition = new Vector3(k, j, i)
                let node = new Node<Vector3>(nodePosition, new List<Node<Vector3>>())
                select node;

            nodes.AddRange(nodesToAdd);
            
            return nodes;
        }
    }
}