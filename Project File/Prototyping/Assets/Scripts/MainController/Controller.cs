﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public Motor m;
    public bool triggerActivated;
    public bool hasControl = false;

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
        hasControl = false;
        m.externalControl = false;
        m.externalController = null;
    }

    public void Attach()
    {
        hasControl = true;
        m = GameObject.FindObjectOfType<Motor>();
        m.externalControl = true;
        m.externalController = this;
    }

}
