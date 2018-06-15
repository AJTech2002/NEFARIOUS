using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphericalConstraint : Constraint {

    public float sphereRadius;
    public Transform relativeObject;
    public Vector3 offset;

    public bool activateClamping;

    Vector3 centerPoint;

    private void Update()
    {
        centerPoint = relativeObject.TransformPoint(offset);
        if (activateClamping)
        {
            transform.position = clampIfNeeded(transform.position);
        }
    }

    
    private void OnDrawGizmosSelected()
    {
        Vector3 c = relativeObject.TransformPoint(offset);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(c, sphereRadius);
    }

    public bool PointIsInSphere (Vector3 point)
    {
        Vector3 originalPoint = centerPoint;
        float radius = sphereRadius;

        Vector3 vecDist = originalPoint - point;
        float fDistSq = Vector3.Dot(vecDist, vecDist);

        if (fDistSq < (radius*radius))
        {
            return true;
        }

        return false;

    }

    public Vector3 closestPointOnBounds(Vector3 point)
    {
        Vector3 originalCenter = centerPoint;
        float radius = sphereRadius;

        Vector3 dif = point - originalCenter;
        Vector3 returnPoint = centerPoint + (radius / dif.magnitude) * dif * 1f;

        return returnPoint;

    }


    public override Vector3 clampIfNeeded (Vector3 point)
    {
        if (PointIsInSphere(point))
            return point;
        else
            return closestPointOnBounds(point);
    }


}
