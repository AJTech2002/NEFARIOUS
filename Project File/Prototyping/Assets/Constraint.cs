using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constraint : MonoBehaviour {
    
    public virtual Vector3 clampIfNeeded (Vector3 point)
    {
        return point;
    }


}
