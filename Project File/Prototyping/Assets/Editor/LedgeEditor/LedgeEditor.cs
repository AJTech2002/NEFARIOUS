using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LedgeEditor : EditorWindow
{

    AIEditor window;

    [MenuItem("Locomotion/Ledge System")]
    static void Init()
    {
        EditorWindow w = (EditorWindow)EditorWindow.GetWindow(typeof(LedgeEditor));
        w.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("Ledge Editor v1");
    }


    // Window has been selected
    void OnFocus()
    {
        // Remove delegate listener if it has previously
        // been assigned.
        SceneView.onSceneGUIDelegate -= this.OnSceneGUI;
        // Add (or re-add) the delegate.
        SceneView.onSceneGUIDelegate += this.OnSceneGUI;
    }

    void OnDestroy()
    {
        // When the window is destroyed, remove the delegate
        // so that it will no longer do any drawing.
        SceneView.onSceneGUIDelegate -= this.OnSceneGUI;
    }


    void OnSceneGUI(SceneView sceneView)
    {
        Handles.BeginGUI();
           
        Handles.EndGUI();

        Handles.DrawLine(GameObject.FindObjectOfType<DrawLine>().transform.position, GameObject.FindObjectOfType<DrawLine>().transform.forward + GameObject.FindObjectOfType<DrawLine>().transform.position);

    }

}
