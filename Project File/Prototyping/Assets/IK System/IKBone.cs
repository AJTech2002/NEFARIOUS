using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKBone : MonoBehaviour {

    public Transform influencer;
    public float influencePower;
    public List<Constraint> constraints = new List<Constraint>();
    public bool hasConstraints;
    public bool isConnecterBone;
    public Transform t
    {
        get
        {
            return transform;
        }
    }
    public Vector3 p
    {
        get
        {
            return transform.position;
        }
    }
    [HideInInspector]
    public Vector3 backwardTemp;
    public Vector3 forwardTemp;
    public Vector3 finalTemp;

    public void SetTheTemps() { backwardTemp = p; forwardTemp = p; }

    public void SetToTemp()
    {
        transform.position = backwardTemp;
    }


    public Vector3 constrainPosition (Vector3 p)
    {
        if (hasConstraints)
        {
            Vector3 n = p;

            for (int i = 0; i < constraints.Count; i++)
            {
                n = constraints[i].clampIfNeeded(n);

            }

            

            return n;

        }
        else
            return p;
    }

}
