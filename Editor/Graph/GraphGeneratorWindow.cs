using System.Collections.Generic;
using System.Linq;
using Graph;
using Nodes;
using UnityEditor;
using UnityEngine;

namespace Editor.Graph
{
    public class GraphGeneratorWindow : EditorWindow
    {
        private const float LayoutSpace = 10f;
        
        private string _graphName = "New Graph";
        private Vector3 _graphSize = Vector3.one;
        private float _scale = 1.0f;
        
        private Vector3 _nodePosition = Vector3.zero;
        private NodeVisualization _defaultConnection;

        private readonly GraphInstantiator _graphInstantiator = new();
        
        [MenuItem("Tools/Sok/GraphGenerator")]
        public static void ShowWindow()
        {
            GetWindow(typeof(GraphGeneratorWindow));
        }

        private void Update()
        {
            Repaint();
        }

        private void OnGUI()
        {
            GUILayout.Label("Graph Generator", EditorStyles.boldLabel);
            
            ShowGraphCreator();
            ShowAddNode();
        }

        private void ShowGraphCreator()
        {
            GUILayout.Space(LayoutSpace);
            GUILayout.Label("New Graph");
            _graphName = EditorGUILayout.TextField("Graph Name", _graphName);
            _graphSize = EditorGUILayout.Vector3Field("Graph Size", _graphSize, GUILayout.ExpandWidth(true));
            _scale = EditorGUILayout.FloatField("Scale", _scale);

            if (!GUILayout.Button("Generate")) return;
            
            var graph = GraphGenerator.Generate(_graphSize);
            _graphInstantiator.Instantiate(_graphName, graph, _scale);
        }

        private void ShowAddNode()
        {
            var selected = Selection.activeGameObject;

            if (selected == null) return;

            var graphContainer = selected.GetComponent<GraphContainer>();
            if (graphContainer == null) return;

            GUILayout.Space(LayoutSpace);
            GUILayout.Label("Add Node");
            _nodePosition = EditorGUILayout.Vector3Field("Node Position", _nodePosition);
            _defaultConnection = EditorGUILayout.ObjectField("Default Connection",_defaultConnection, 
                    typeof(NodeVisualization), true) as NodeVisualization; ;

            if (!GUILayout.Button("Add Node")) return;
            
            var connection = GetDefaultConnection(graphContainer);
            var newNode = new Node(_nodePosition);
            _graphInstantiator.InstantiateNode(newNode, graphContainer);
        }

        private Node GetDefaultConnection(GraphContainer graphContainer)
        {
            Node connection;
            if (_defaultConnection == null)
            {
                connection = graphContainer.Nodes.First();
            }
            else
            {
                connection = graphContainer.Nodes
                    .FirstOrDefault(node => node.Visualization == _defaultConnection);
            }

            return connection;
        }
    }
}