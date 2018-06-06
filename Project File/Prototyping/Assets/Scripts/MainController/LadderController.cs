using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderController : Controller
{

    

    public override void ExternalFixedUpdate()
    {
        motorRef.finalVelocity += Vector3.up;
        motorRef.CalculateRawMovement();
    }

}

