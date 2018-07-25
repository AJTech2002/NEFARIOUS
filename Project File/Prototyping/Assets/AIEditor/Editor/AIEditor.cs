using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
