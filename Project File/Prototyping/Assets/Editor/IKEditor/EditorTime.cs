using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using IK;

[CustomEditor(typeof(FootIK))]
[CanEditMultipleObjects]
public class EditorTime : Editor {

    FootIK IkObject;

    private void OnEnable()
    {
        IkObject = (FootIK)target;
    }

    int layer = 0;
    float timeRelu = 0f;
    public override void OnInspectorGUI()
    {

        if (IkObject.anim != null)
        {
            timeRelu += Time.deltaTime;

            layer = Mathf.RoundToInt(GUILayout.HorizontalSlider(layer,0,10));
            GUILayout.Label("Currently Playing : " + IkObject.anim.GetCurrentAnimatorStateInfo(layer).length);

            if (timeRelu >= IkObject.anim.GetCurrentAnimatorStateInfo(layer).length)
                timeRelu = 0f;

            GUILayout.Label("Current Time : " + timeRelu);
            GUILayout.Label("Percentage Time : " + (timeRelu / IkObject.anim.GetCurrentAnimatorStateInfo(layer).length));

            if (GUILayout.Button("Pause/Play"))
            {
                if (IkObject.anim.speed > 0.1f)
                IkObject.anim.speed = 0f;
                else
                    IkObject.anim.speed = 1f;
            }

        }

        base.OnInspectorGUI();
    }


}
