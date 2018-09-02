using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using AJTech.Editor;

namespace AJTech.Editor {

    public class AIEditor : EditorWindow {

        AIEditor window;

        [MenuItem("AI/Node Editor")]
        static void Init()
        {
            EditorWindow w = (EditorWindow)EditorWindow.GetWindow(typeof(AIEditor));
            w.Show();
        }

        private void OnGUI()
        {
            GUILayout.Label("Node Editor v1");
        }

    }

    [System.Serializable]
    public class NodeManagement
    {
        public List<Node> nodes = new List<Node>();

        public enum FilterMode {Name,Category};

        public List<Node> Filter()
        {

            return null;
        }

    }

}