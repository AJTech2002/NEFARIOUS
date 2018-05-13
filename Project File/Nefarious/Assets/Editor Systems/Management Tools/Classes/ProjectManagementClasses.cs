using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TreeEditor;
using UnityEditor;

namespace  ProjectManagementClasses {
    [System.Serializable]
    public class Event
    {
        public string name;
        public string description;
        public List<Event> nestedEvents = new List<Event>();
        public string notes;
        public List<TODO> todos = new List<TODO>();
        public bool completedEvent;

        public float progress = 0;
        public Date startDate = new Date();
        public Date endDate = new Date();

        public Tag EventTag;
        
    }

    [System.Serializable]
    public class TODO
    {
        public string todoName = "";
        public List<string> todoEvents = new List<string>();
        public List<bool> hasCompleted = new List<bool>();
    }

    [System.Serializable]
    public class Date
    {
        public int day;
        public int month;
        public int year;
    }

    [System.Serializable]
    public class Tag
    {
        public string nameTag;
        public Color colorTag;
        
    }

    public class FoldoutView {
        public List<FoldoutObject> foldOutObjects = new List<FoldoutObject>();
        public int maxDepthLevel;
        public Vector2 startPosition;
        public float foldoutObjectHeight = 50;
        public float foldoutObjectWidth = 100;
        public void DrawFoldoutView ()
        {
            Vector2 sPos = startPosition;

            for (int i = 0; i < foldOutObjects.Count; i++)
            {

                Vector2 currentFoldout = new Vector2(sPos.x, sPos.y + (i * foldoutObjectHeight));
                if (i != 0)
                currentFoldout = new Vector2(sPos.x, sPos.y + ((i+foldOutObjects[i-1].maxDepthLevel) * foldoutObjectHeight));

                foldOutObjects[i].parent = foldOutObjects[i];
                foldOutObjects[i].DrawAtDepth(0,currentFoldout,foldoutObjectHeight,foldoutObjectWidth,0);

            }
        }

    }
    
    public class FoldoutObject
    {
        public string name;
        public int depthLevel;
        public int maxDepthLevel;

        public float moveTo = 50;

        public List<FoldoutObject> nestedFoldouts = new List<FoldoutObject>();

        public FoldoutObject parent;

        public void DrawAtDepth (int d, Vector2 pos, float height, float width, float yAdd)
        {
            depthLevel = d;
            if (parent.maxDepthLevel < depthLevel)
                parent.maxDepthLevel = depthLevel;

            Vector2 p = pos;
            p.x += moveTo*depthLevel;
            p.y += yAdd;
            //This will draw the current then we will go into the children
            GUI.Box(new Rect(p, new Vector2(width,height)), name);

            for (int i = 0; i < nestedFoldouts.Count; i++)
            {
                nestedFoldouts[i].parent = parent;
                nestedFoldouts[i].DrawAtDepth(depthLevel++, pos, height, width, (i+1)*height);
            }
            
        }
    }
}
