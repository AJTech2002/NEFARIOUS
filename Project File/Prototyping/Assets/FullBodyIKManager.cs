using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullBodyIKManager : MonoBehaviour {

    [Header("MainAspects")]
    public bool drawGizmos;
    public Transform rootBone;

   

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        foreach (Transform t in rootBone.GetComponentsInChildren<Transform>())
        {
            if (t.parent != null)
            Gizmos.DrawLine(t.parent.position, t.position);
        
        }
    }
}
