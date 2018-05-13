using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using ProjectManagementClasses;

public class ProjectManager : EditorWindow {

    [MenuItem("Management/Manager Main")]
    private static void Init()
    {
        EditorWindow w = EditorWindow.GetWindow(typeof(ProjectManager), false, "Project Manager");
        w.Show();
    }

    FoldoutView view = new FoldoutView();
    private void OnGUI()
    {
        
        if (GUI.Button(new Rect(new Vector2(10,10),Vector2.one*30),"YE"))
        {

            FoldoutObject a = new FoldoutObject();
            for (int i = 0; i < 3; i++)
            {
                a.nestedFoldouts.Add(new FoldoutObject());
            }
            FoldoutObject b = new FoldoutObject();
            for (int i = 0; i < 1; i++)
            {
                b.nestedFoldouts.Add(new FoldoutObject());
            }
            FoldoutObject c = new FoldoutObject();
            for (int i = 0; i < 0; i++)
            {
                c.nestedFoldouts.Add(new FoldoutObject());
            }


            view.foldOutObjects.Add(a);
            view.foldOutObjects.Add(b);
            view.foldOutObjects.Add(c);
            view.startPosition = new Vector2(100, 100);
   
        }

        view.DrawFoldoutView();
        
        Repaint();
    }



    #region Helpers

    private bool dropped;
    // private Vector2 dropVect;

    Rect r(float x, float y, float xS, float yS)
    {
        return new Rect(new Vector2(x, y), new Vector2(xS, yS));
    }

    Rect r(float x, float y, float xS, float yS, out Rect rectOut)
    {
        rectOut = new Rect(new Vector2(x, y), new Vector2(xS, yS));
        return new Rect(new Vector2(x, y), new Vector2(xS, yS));
    }

    Rect o(Rect r, float xOff, float yOff, float xS, float yS)
    {
        return new Rect(new Vector2(r.x + xOff, r.y + yOff), new Vector2(xS, yS));
    }

    Rect xo(Rect r, float xOff, float yOff, float xS, float yS)
    {
        return new Rect(new Vector2(r.x + xOff + r.size.x, r.y + yOff), new Vector2(xS, yS));
    }

    Rect yo(Rect r, float xOff, float yOff, float xS, float yS)
    {
        return new Rect(new Vector2(r.x + xOff, r.y + yOff + r.size.y), new Vector2(xS, yS));
    }

    Rect o(Rect r, float xOff, float yOff, float xS, float yS, out Rect rectOut)
    {
        rectOut = new Rect(new Vector2(r.x + xOff, r.y + yOff), new Vector2(xS, yS));
        return new Rect(new Vector2(r.x + xOff, r.y + yOff), new Vector2(xS, yS));
    }

    private void DrawRectBox(Rect rect, string text, out Rect r)
    {
        GUI.Box(rect, text);
        r = rect;
    }

    private void DrawRectBox(Rect rect, string text)
    {
        GUI.Box(rect, text);
    }

    private float width
    {
        get
        {
            return Screen.width;
        }
    }

    private float height
    {
        get
        {
            return Screen.height;
        }
    }



    #endregion

}
