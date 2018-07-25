using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeController : Controller {


    private void Awake()
    {
       
    }

    public override void ExternalFixedUpdate()
    {
        m.rBody.isKinematic = true;
       
    }

    public void ResetPosition (Vector3 hitPosition, Vector3 myDir)
    {
    }
    
}
