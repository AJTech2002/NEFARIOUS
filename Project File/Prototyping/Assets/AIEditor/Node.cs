using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AJTech.AI;
using System.Reflection;
using AJTech.Management;

namespace AJTech.Editor
{
    public class Node
    {

        public string nodeName;
        public Vector2 position;

        public Vector2 nodeSize;
        

        public virtual void DrawNode ()
        {
            DrawOuterFrame();
        }

        private void DrawOuterFrame()
        {
            GUI.Box(Tools.r(position.x, position.y, nodeSize.x, nodeSize.y), "");
        }

    }


    public class Tools
    {
        #region Helpers
        public static Rect r(float x, float y, float xS, float yS)
        {
            return new Rect(new Vector2(x, y), new Vector2(xS, yS));
        }

        public static Rect o(Rect r, float xOff, float yOff, float xS, float yS)
        {
            return new Rect(new Vector2(r.x + xOff, r.y + yOff), new Vector2(xS, yS));
        }

        public static Rect duplicate(Rect r, float xOff, float yOff)
        {
            return new Rect(new Vector2(r.x + xOff, r.y + yOff), r.size);
        }

        public static Texture2D MakeTex(int width, int height, Color col)
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

   
   

}