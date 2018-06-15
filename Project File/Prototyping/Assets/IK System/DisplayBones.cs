using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayBones : MonoBehaviour {

    public Transform root;

    private void OnDrawGizmos()
    {
        foreach (Transform t in root.GetComponentsInChildren<Transform>())
        {
            if (t.parent != null)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(t.parent.position, t.position);
            }
        }
    }

}
