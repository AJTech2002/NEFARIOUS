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
        if (t.useCustomContraint)
            dir = t.directionFacing;
        float height = t.originalDistance;
        float r = t.coneRadiusX;

        Vector3 p = t.ikTestingBone.position;

        //Figures how far it is from the cone point I think
        float coneDist = Vector3.Dot(p - x, dir);
        //Find out the radius when p is at it's point based on radius and height of cone
        float cone_radius = (coneDist / height) * r;
        //Finds out the distance between p and x on a plane
        float orthDist = ((p - x) - coneDist * dir).magnitude;

        if (t.isCone)
        {
            bool isPointInsideCone = (orthDist < cone_radius);

            if (isPointInsideCone)
                Handles.color = new Color(0, 1, 0, 0.1f);
            else
            {


                Vector3 dirr = (t.ikTestingBone.position - (t.holderBone.position + (dir * coneDist))).normalized;
                float dis = 0.5f * (Vector3.Distance(t.ikTestingBone.position, t.holderBone.position) / t.originalDistance);

                dirr = Vector3.ClampMagnitude(dirr, cone_radius);

                Handles.color = new Color(0, 0, 1, 1);
                Handles.DrawCube(0, (t.holderBone.position + (dir * coneDist)) + dirr, Quaternion.identity, 0.1f);
                Handles.color = new Color(1, 0, 0, 0.15f);
                //Handles.DrawWireCube()
            }


            Handles.DrawCylinder(0, t.holderBone.position + (dir * coneDist), Quaternion.FromToRotation(t.holderBone.forward, (dir * coneDist)), cone_radius * 2);

            Handles.color = new Color(0, 1, 1, 0.15f);
            Handles.DrawSolidDisc(t.holderBone.position + (dir * coneDist), dir, cone_radius);
        }
        else if (t.isElipse)
        {

            Vector3 elipseCenter = t.holderBone.position + (dir * coneDist);
            
            /*
            Handles.DrawLine(elipseCenter + yS, elipseCenter);
            Handles.DrawLine(elipseCenter - yS, elipseCenter);
            Handles.DrawLine(elipseCenter + xS, elipseCenter);
            Handles.DrawLine(elipseCenter - xS, elipseCenter);
            */
            // Handles.DrawLine(elipseCenter, elipseCenter + pointBetween);




        }



    }
}
