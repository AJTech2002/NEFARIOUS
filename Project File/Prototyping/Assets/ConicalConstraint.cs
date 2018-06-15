using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConicalConstraint : Constraint {

    [Header("ConstrainTesting")]
    public bool isRelativeToHoldingParent;
    public bool useCustomContraint;
    [Header("Shape")]
    public bool isCone;
    public bool isSemiCircle;
    public bool isElipse;

    [Header("Transforms")]
    public Transform holderBone;
    public Transform holderBoneParent;
    public Transform ikTestingBone;

    [Header("Elipse Options")]
    [Range(0f,21f)]
    public float xStretch;
    [Range(0f, 21f)]
    public float yStretch;


    [Header("Semi-Circle Options")]
    public int posNeg = 1;
    public float fatnessP;
    public float boldnessB;

    [Header("Cone Values")]
    public float coneRadiusX;
    public Vector3 customConstraintDirection;
    //public float coneRadiusY;

    [HideInInspector]
    public Vector3 directionFacing;
    [HideInInspector]
    public float originalDistance;

    public bool clampOnNeed;

    private void Awake()
    {
        //Set in stone since it is hip bone
        if (!isRelativeToHoldingParent)
            directionFacing = ikTestingBone.position - holderBone.position;
        else if (isRelativeToHoldingParent && !useCustomContraint)
            directionFacing = holderBone.position - holderBoneParent.position;

        if (useCustomContraint)
            directionFacing = customConstraintDirection;

        originalDistance = Vector3.Distance(ikTestingBone.position, holderBone.position);

    }

    private void LateUpdate()
    {
        if (isRelativeToHoldingParent && !useCustomContraint)
        directionFacing = holderBone.position - holderBoneParent.position;
        // coneRadiusX = 0.5f*Vector3.Distance(ikTestingBone.position, holderBone.position) / originalDistance;

        if (clampOnNeed)
            transform.position = clampIfNeeded(transform.position);

    }


    public override Vector3 clampIfNeeded(Vector3 point)
    {
        Vector3 x = holderBone.position;
        Vector3 dir = directionFacing.normalized;
        if (useCustomContraint)
            dir = directionFacing;
        float height = originalDistance;
        float r = coneRadiusX;

        Vector3 p = point;

        float coneDist = Vector3.Dot(p - x, dir);
        float cone_radius = (coneDist / height) * r;
        float orthDist = ((p - x) - coneDist * dir).magnitude;

        if (isCone)
        {
            bool isPointInsideCone = (orthDist < cone_radius);

            if (isPointInsideCone == true)
                return point;

            Vector3 dirr = (p - (holderBone.position + (dir * coneDist))).normalized;


            dirr = Vector3.ClampMagnitude(dirr, cone_radius);
            Vector3 c = (holderBone.position + (dir * coneDist)) + dirr;
            return c;
        }
        else if (isElipse)
        {

        }

        return point;
    }

}
