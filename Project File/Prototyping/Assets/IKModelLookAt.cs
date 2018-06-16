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

    private void LateUpdate()
    {
        SolveModel();
    }

}
