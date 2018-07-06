using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;

public class FootIKWindow : EditorWindow {
    
    [MenuItem("IK/FootWindow")]
     static void Init()
    {
        FootIKWindow w = (FootIKWindow)EditorWindow.GetWindow(typeof(FootIKWindow), false);
        w.Show();
    }

    private void OnGUI()
    {

        StatusWindow();

    }

    private void StatusWindow()
    {
        Rect prev = new Rect();

        Rect StatusRect = r(0, 0, 400, 200);
        GUI.Box(StatusRect, "");

        
        GUI.Label(oOut(StatusRect,5,20,395,20,out  prev),"Left Foot Contact : FALSE");
        
        GUI.Label(oOut(prev, 0, 20, 395, 20, out prev),"Right Foot Contact : FALSE");



    }

    #region Helpers
    Rect r(float x, float y, float xS, float yS)
    {
        return new Rect(new Vector2(x, y), new Vector2(xS, yS));
    }
    Rect rOut(float x, float y, float xS, float yS, out Rect a)
    {
        Rect rect = new Rect(new Vector2(x, y), new Vector2(xS, yS));
        a = rect;
        return rect;
    }

    Rect o(Rect r, float xOff, float yOff, float xS, float yS)
    {
        return new Rect(new Vector2(r.x + xOff, r.y + yOff), new Vector2(xS, yS));
    }
    Rect oOut(Rect r, float xOff, float yOff, float xS, float yS, out Rect a)
    {
        Rect l = new Rect(new Vector2(r.x + xOff, r.y + yOff), new Vector2(xS, yS));
        a = l;
        return l;
    }

    Rect duplicate(Rect r, float xOff, float yOff)
    {
        return new Rect(new Vector2(r.x + xOff, r.y + yOff), r.size);
    }

    private Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; ++i)
        {
            pix[i] = col;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }
    #endregion


}
