using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public Motor motorRef;

    private void Awake()
    {
        motorRef = GameObject.FindObjectOfType<Motor>();
    }

    public virtual void ExternalFixedUpdate()
    {
        
    }

    public virtual void ExternalUpdate()
    {

    }

    public void Detach()
    {
        motorRef.externalControl = false;
        motorRef.externalController = null;
    }

    public void Attach()
    {
        motorRef = GameObject.FindObjectOfType<Motor>();
        motorRef.externalControl = true;
        motorRef.externalController = this;
    }

}
