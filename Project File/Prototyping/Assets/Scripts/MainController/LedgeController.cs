using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LedgeSystem;

public class LedgeController : Controller {

    //PRIVATE VARS
    private Vector3 hitPosition;
    private Vector3 myDir;
    private bool firstTime = false;

    public bool inMotion;

    private void Awake()
    {
       
    }

    public override void ExternalFixedUpdate()
    {
        if (m.rBody.isKinematic == false)
            m.rBody.isKinematic = true;

        FirstTimeClamp();


        if (Input.GetMouseButtonDown(0))
        {
            m.rBody.isKinematic = false;

            m.transform.position -= transform.forward;

            Detach();


        }
    }



    private float speed;
    private LedgeConnection.ConnectionType connectionType;
    private bool isJump;
   

    private void FirstTimeClamp()
    {
        //
        if (Vector3.Distance(m.transform.position, goTo) > 0.02f && firstTime == false)
        {

            inMotion = true;

            //m.transform.LookAt(transform.position + myDir);


            m.transform.position = Vector3.Lerp(m.transform.position, goTo, speed * Time.deltaTime);

 
        }
        else
        {

            inMotion = false;
            
            firstTime = true;
            if (dismount)
            {
                m.rBody.isKinematic = false;
                Detach();

            }
        }


        if (isJump && Vector3.Distance(m.transform.position, goTo) <= 0.5f)
        {
            mot.FinishedJump();
        }

        //
    }

    LedgeMotor mot;
    bool dismount = false;
    Vector3 goTo;

    public void ResetPosition (Vector3 hitPosition, Vector3 myDir, float speed, LedgeMotor motor, Vector3 p, bool dismount, bool isJump)
    {
        goTo = p;
        mot = motor;
        firstTime = false;
        this.hitPosition = hitPosition;
        this.myDir = myDir;
        this.speed = speed;
        this.dismount = dismount;
        this.isJump = isJump;
    }
    
}
