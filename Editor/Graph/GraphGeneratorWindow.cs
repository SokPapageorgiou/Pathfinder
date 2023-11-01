using System;
using Graph;
using UnityEditor;
using UnityEngine;

namespace Editor.Graph
{
    public class GraphGeneratorWindow : EditorWindow
    {
        private const float LayoutSpace = 10f;
        
        private string _graphName = "New Graph";
        private Vector3 _graphSize = Vector3.one;
        private float _distanceBetweenNodes = 1.0f;
        
        private Vector3 _nodePosition = Vector3.zero;
        
        private readonly GraphGenerator _graphGenerator = new();
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
            
            GUILayout.Space(LayoutSpace);
            GUILayout.Label("New Graph");
            _graphName = EditorGUILayout.TextField("Graph Name", _graphName);
            _graphSize = EditorGUILayout.Vector3Field("Graph Size", _graphSize, GUILayout.ExpandWidth(true));
            _distanceBetweenNodes = EditorGUILayout.FloatField("Distance Between Nodes", _distanceBetweenNodes);

            if (GUILayout.Button("Generate"))
            {
                var graph = _graphGenerator.Generate(_graphSize * _distanceBetweenNodes);
                _graphInstantiator.Instantiate(_graphName, graph);
            }
            
            var selected = Selection.activeGameObject;
            
            if(selected == null) return;

            var graphContainer = selected.GetComponent<GraphContainer>();
            if (graphContainer == null) return;
            
            GUILayout.Space(LayoutSpace);
            GUILayout.Label("Add Node");
            _nodePosition = EditorGUILayout.Vector3Field("Node Position", _nodePosition);

            if (GUILayout.Button("Add Node"))
            {
                
            }
        }
    }
}