using Graph;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Runtime.Graph
{
    public class GraphGeneratorTest
    {
        private readonly GraphGenerator _graphGenerator;
        
        public GraphGeneratorTest()
        {
            _graphGenerator = new GraphGenerator();
        }
        
        [Test]
        public void Generate_GivenAnySize_ReturnsGraph()
        {
            var graph = _graphGenerator.Generate(Vector3.one);
            
            Assert.IsNotNull(graph);
        }
        
        [Test]
        public void Generate_GivenVector3_One_ReturnsGraphWithOneNode()
        {
            var graph = _graphGenerator.Generate(Vector3.one);
            
            Assert.AreEqual(1, graph.Count);
        }
        
        [Test]
        public void Generate_GivenVector3_10_10_10_ReturnsGraphWith1000Nodes()
        {
            var graph = _graphGenerator.Generate(new Vector3(10, 10, 10));
            
            Assert.AreEqual(1000, graph.Count);
        }
    }
}