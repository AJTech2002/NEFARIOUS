using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class AutoBackupEditor : EditorWindow {

    private string backupPath;

    [MenuItem("Management/Backup")]
    private static void Init()
    {
        EditorWindow w = EditorWindow.GetWindow(typeof(AutoBackupEditor), false, "Auto Backup");
        w.Show();
    }

    //Get backup path
    //Get the current month
    //Split by date
    //Save all files... Including the LOG Files.

    private void OnGUI()
    {
        BackupGUI();
    }

    //Folder selection and change detection (Search up)s
    //Get list of names folders and backup those to a specified point (save txt data to Player Prefs)
    private void BackupGUI()
    {
        Rect bPathRect = new Rect(new Vector2(20, 20), new Vector2(Screen.width - 40, 20));
        backupPath = GUI.TextField(bPathRect,backupPath);

        if (GUILayout.Button("Backup Directories"))
        {

            string[] filePaths = Directory.GetDirectories(Application.dataPath + "/" + backupPath);
            for (int i = 0; i < filePaths.Length; i++)
            {
                Debug.Log(filePaths[i]);
            }
            

        }

    }

}
