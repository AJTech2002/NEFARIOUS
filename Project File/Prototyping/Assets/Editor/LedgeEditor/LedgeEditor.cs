using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using LedgeSystem;

public class LedgeEditor : EditorWindow
{

    [MenuItem("Locomotion/Ledge System")]
    static void Init()
    {
        EditorWindow w = (EditorWindow)EditorWindow.GetWindow(typeof(LedgeEditor));
        w.Show();
    }

    private void OnGUI()
    {
      
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
        SceneView.RepaintAll();

    }

}

/*
        GUILayout.Label("Ledge Editor v1");
        MeshFilter go = GameObject.FindObjectOfType<DrawLine>().GetComponent<MeshFilter>();
        Vector3[] v = go.sharedMesh.vertices;
        Camera c = Camera.main;
        for (int i = 0; i < v.Length; i++)
        {
            Vector3 a = HandleUtility.WorldToGUIPoint(go.transform.TransformPoint(v[i]));
            if (GUI.Button(new Rect(new Vector2(a.x, a.y), new Vector2(20, 20)), i.ToString()))
            {
                Debug.Log(i);
            }
        }

 */


