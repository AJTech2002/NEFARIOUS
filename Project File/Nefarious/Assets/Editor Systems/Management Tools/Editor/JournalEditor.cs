using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;


/* This journal system will be responsible for creating the DEVELOPMENT LOGS which will be 
 * published onto my local website every day, it will save my logs based on time and script */

public class JournalEditor : EditorWindow {

    #region Variables
    private string locPath = "LOGS";
    private string month = "";
    private string currentLog = "";
    private string finalPath = "";
    private Object currentObject;
    #endregion

    #region Main Methods
    [MenuItem("Management/Logger")]
    private static void Init() {
        EditorWindow w = EditorWindow.GetWindow(typeof(JournalEditor),false,"Logger");
        w.Show();
    }

    private void OnGUI()
    {
        DrawDateTime();
        LogButton();
        Repaint();
    }
    #endregion


    #region GUI
    private void DrawDateTime() {
        //Using the System.DateTime to collect current time information
        System.DateTime dateTime = System.DateTime.Now;

        if (month == "")
            month = dateTime.Month.ToString();

        //Displaying all GUI elements using Rect 
        Rect date = new Rect(new Vector2(20,20),new Vector2(100,20));
        GUI.Label(date,dateTime.ToShortDateString());

        Rect time = new Rect(new Vector2(Screen.width-80,20),new Vector2(80,20));
        GUI.Label(time,dateTime.ToShortTimeString());

        Rect input = new Rect(new Vector2(20,60), new Vector2(Screen.width-40,Screen.height/3-140));
        Rect outputObject = new Rect(new Vector2(20,80+Screen.height/3-140),new Vector2(Screen.width-40,Screen.height - 240));

        currentLog = GUI.TextArea(input,currentLog);

        string editMode = "------------------------------------EDITING------------------------------------" + "\n";

        if (finalPath != "") {
            if (File.Exists(finalPath)) {
                GUI.TextArea(outputObject,editMode + File.ReadAllText(finalPath).ToString());
            }
        }

        Rect inputObject = new Rect(new Vector2(20,Screen.height-70),new Vector2(Screen.width-40,20));
       
        //Allowing input of an object to specify what the log is about (Optional Field)
        currentObject = (Object)EditorGUI.ObjectField(inputObject,currentObject,typeof(Object));



    }

    //This is the handling of the saving of the journal / making folders etc...
    private void LogButton() {

        Rect logButton = new Rect(new Vector2(120,15), new Vector2(Screen.width-240,30));
        if (GUI.Button(logButton,"LOG")) {
            CreateDirectory("/"+locPath+"/"+month);
        }

    }

    private void CreateDirectory (string path) {
        string p = Application.dataPath+path;

        if (Directory.Exists(p)) {
            Debug.Log("EXISTS");
        }
        else {
            Directory.CreateDirectory(p);
        }

        string newPath = System.DateTime.Now.Day.ToString() + " " + System.DateTime.Now.Month.ToString() + " " + System.DateTime.Now.Year.ToString();
        CreateFile(p+"/"+newPath);

    }

    private void CreateFile (string path) {
        finalPath = path + ".txt";
        if (File.Exists(path+".txt")) {

            string prev = File.ReadAllText(path+".txt").ToString();
            File.WriteAllText(path+".txt",prev+"\n"+ReturnLogString());
         
        }
        else {
          
            string d = ("[" + System.DateTime.Now.ToShortDateString() + "]");
            string r = (ReturnLogString());
            File.WriteAllText(path+".txt",d+"\n"+"\n"+r);


        }
    }

    private string ReturnLogString () {
        string retStr = "";
        if (currentObject != null) {
            retStr = "[" + currentObject.name + "]:["+System.DateTime.Now.ToShortTimeString()+"] : " + currentLog;
        }
        else {
            retStr = "["+System.DateTime.Now.ToShortTimeString()+"] : " + currentLog;
        }

        currentLog = "";

        return retStr;

    }

    #endregion

}
