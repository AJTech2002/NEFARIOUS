using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ConicalConstraint))]
[CanEditMultipleObjects]
public class ConeEditor : Editor {
    public float coneSize = 1;

    void OnSceneGUI()
    {
        ConicalConstraint t = target as ConicalConstraint;


        if (!EditorApplication.isPlaying)
        {

            t.originalDistance = Vector3.Distance(t.ikTestingBone.position, t.holderBone.position);

            if (!t.isRelativeToHoldingParent)
                 t.directionFacing = t.ikTestingBone.position - t.holderBone.position;
            else if (t.isRelativeToHoldingParent && t.useCustomContraint == false)
                t.directionFacing = t.holderBone.position - t.holderBoneParent.position;

            if (t.useCustomContraint)
            {
                t.directionFacing = t.customConstraintDirection;
             
            }
            Handles.color = Color.red;
            Handles.DrawDottedLine(t.holderBone.position, t.holderBone.position + (t.directionFacing.normalized * t.originalDistance), 4f);
            
        }
        Vector3 x = t.holderBone.position;
        Vector3 dir = t.directionFacing.normalized;
        float height = t.originalDistance;
        float r = t.coneRadiusX;

        Vector3 p = t.ikTestingBone.position;

        float coneDist = Vector3.Dot(p - x, dir);
        float cone_radius = (coneDist / height) * r;
        float orthDist = ((p - x) - coneDist * dir).magnitude;

        bool isPointInsideCone = (orthDist < cone_radius);

        if (isPointInsideCone)
            Handles.color = new Color(0, 1, 0, 0.1f);
        else
        {
           

            Vector3 dirr = (t.ikTestingBone.position - (t.holderBone.position + (t.directionFacing.normalized * coneDist))).normalized;
            float dis = 0.5f * (Vector3.Distance(t.ikTestingBone.position, t.holderBone.position) / t.originalDistance);

            dirr = Vector3.ClampMagnitude(dirr,cone_radius);

            Handles.color = new Color(0, 0, 1, 1);
            Handles.DrawCube(0, (t.holderBone.position + (t.directionFacing.normalized * coneDist)) + dirr, Quaternion.identity, 0.1f);
            Handles.color = new Color(1, 0, 0, 0.15f);
            //Handles.DrawWireCube()
        }

        
        Handles.DrawCylinder(0, t.holderBone.position + (t.directionFacing.normalized * coneDist), Quaternion.FromToRotation(t.holderBone.forward, (t.directionFacing.normalized * coneDist)), cone_radius*2);

        Handles.color = new Color(0, 1, 1, 0.15f);
        Handles.DrawSolidDisc(t.holderBone.position+(t.directionFacing.normalized*coneDist), t.directionFacing, cone_radius);
       

    }
}
