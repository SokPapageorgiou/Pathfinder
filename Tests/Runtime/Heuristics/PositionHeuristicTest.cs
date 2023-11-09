using Heuristics;
using Nodes;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Runtime.Heuristics
{
    public class PositionHeuristicTest
    {
        private PositionHeuristic _positionHeuristic;
        
        [SetUp]
        public void SetUp()
        {
            var goalNode = new Node(new Vector3(10,0,0));

            _positionHeuristic = new PositionHeuristic(goalNode);
        }
        
        [Test]
        public void Estimate_WhenCalledWithNode_ReturnsDistanceBetweenNodeAndGoalNode()
        {
            var node = new Node(new Vector3(0,0,0));
            
            var result = _positionHeuristic.Estimate(node);
            
            Assert.AreEqual(10, result);
        }
        
        [Test]
        public void Estimate_WhenCalledWithTwoNodes_ReturnsDistanceBetweenNodes()
        {
            var fromNode = new Node(new Vector3(0,0,0));
            var toNode = new Node(new Vector3(5,0,0));
            
            var result = _positionHeuristic.Estimate(fromNode, toNode);
            
            Assert.AreEqual(5, result);
        }
    }
}