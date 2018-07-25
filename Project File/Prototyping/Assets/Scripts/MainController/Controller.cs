using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public Motor m;
    public bool triggerActivated;

    private void Awake()
    {
        m = GameObject.FindObjectOfType<Motor>();
    }

    public virtual void ExternalFixedUpdate()
    {
        
    }

    public virtual void ExternalUpdate()
    {

    }

    public void Detach()
    {
        m.externalControl = false;
        m.externalController = null;
    }

    public void Attach()
    {
        m = GameObject.FindObjectOfType<Motor>();
        m.externalControl = true;
        m.externalController = this;
    }

}
