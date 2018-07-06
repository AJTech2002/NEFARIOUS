using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKModelLookAt : MonoBehaviour {


    public bool lookAtConnector;
    public Transform connectorTransform;
    public Vector3 rotationAxis;
    public Vector3 modelOffset;
    public Transform model;

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position,transform.position + rotationAxis);

    }

    public void SolveModel()
    {
        if (!lookAtConnector)
            model.LookAt(transform.position + (connectorTransform.position - transform.position).normalized, rotationAxis);
        else
            model.LookAt(connectorTransform, rotationAxis);
        model.Rotate(modelOffset);
    }

    
    public void LookAt (Vector3 v, float influence)
    {
        model.LookAt(Vector3.Lerp(transform.position + (connectorTransform.position - transform.position).normalized, transform.position + (v - transform.position).normalized, influence), Vector3.up);
        model.Rotate(modelOffset);
    }


}
