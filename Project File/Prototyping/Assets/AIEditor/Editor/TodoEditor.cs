using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using AJTech.Editor;

namespace AJTech.Editor {

    public class TodoEditor : EditorWindow {

        TodoEditor window;

        [SerializeField]
        public class List
        {
            public List<Todo> list = new List<Todo>();
        }

        List currentList = new List();


        [MenuItem("Tools/TODO")]
        static void Init()
        {
            EditorWindow w = (EditorWindow)EditorWindow.GetWindow(typeof(TodoEditor));
            w.Show();
        }


        Vector2 scroll;
        bool breaketh = false;
        string lastestControlId = "0";
        private void OnGUI()
        {
            GUI.SetNextControlName("Save");
            if (GUILayout.Button("Save"))
            {
                string s = JsonUtility.ToJson(currentList);

                TextWriter w = new StreamWriter(Application.dataPath + "/saveTodo.json");
                w.Write(s);
                w.Close();

            }

            if (GUILayout.Button("Load"))
            {
                TextReader r = new StreamReader(Application.dataPath + "/saveTodo.json");
                currentList = JsonUtility.FromJson<List>(r.ReadToEnd());
                r.Close();
            }

            GUILayout.Space(5);

            GUILayout.Label("TODO LIST EDITOR");
            GUILayout.Label("Number of Elements : " + currentList.list.Count.ToString());
            GUILayout.Space(5);
            
            if (GUILayout.Button("Clear"))
            {
                currentList.list.Clear();
            }
            if (GUILayout.Button("Add"))
            {
                currentList.list.Add(new Todo());
            }

            
            Vector2 startPoint = new Vector2(0, 0);
            scroll = GUI.BeginScrollView(new Rect(0, 140, position.width, position.height-140), scroll, new Rect(0, 0, position.width, (position.height-140)+(70*currentList.list.Count)), false, true);
            for (int i = 0; i < currentList.list.Count; i++)
            {
                if (currentList.list[i].completed)
                    currentList.list.RemoveAt(i);
                if (currentList.list[i] != null)
                {
                    Vector2 currentPoint = new Vector2(startPoint.x, startPoint.y + (70 * i));
                    Vector2 size = new Vector2(position.width, 80);
                    GUI.Box(new Rect(currentPoint, size), "");
                    
                    GUI.SetNextControlName(i.ToString());
                    currentList.list[i].name = GUI.TextArea(new Rect(new Vector2(currentPoint.x + 5, currentPoint.y + 5), new Vector2(position.width - 40, 40)), currentList.list[i].name);
                    currentList.list[i].completed = GUI.Toggle(new Rect(new Vector2(currentPoint.x + 5, currentPoint.y + 50), new Vector2(position.width/3, 20)), currentList.list[i].completed, "Completed?");

                    if (breaketh == false && i.ToString().Equals(lastestControlId))
                    {
                        GUI.FocusControl(i.ToString());
                        breaketh = true;
                    }
                }
            }

            if (Event.current.keyCode == KeyCode.Return && Event.current.type == EventType.KeyUp)
            {
                
                currentList.list.Add(new Todo());
                breaketh = false;
                lastestControlId = (currentList.list.Count - 1).ToString();
            }

            if (Event.current.control == true && Event.current.keyCode == KeyCode.LeftControl && Event.current.type == EventType.KeyUp)
            {

                string s = JsonUtility.ToJson(currentList);

                TextWriter w = new StreamWriter(Application.dataPath + "/saveTodo.json");
                w.Write(s);
                w.Close();

                Debug.Log("SAVED");
            }

            GUI.EndScrollView();

            Repaint();

        }

    }

    
    
}

[System.Serializable]
public class Todo
{
    [SerializeField]
    public string name;
    [SerializeField]
    public bool completed;

}