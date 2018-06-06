using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeController : Controller {


    private void Awake()
    {
        Attach();
    }

    public override void ExternalFixedUpdate()
    {
       motorRef.finalVelocity += Vector3.one;
       motorRef.CalculateRawMovement();
    }

}
