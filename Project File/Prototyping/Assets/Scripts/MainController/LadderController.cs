using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderController : Controller
{

    

    public override void ExternalFixedUpdate()
    {
        m.finalVelocity += Vector3.up;
        m.CalculateRawMovement();
    }

}

