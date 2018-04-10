using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //This controller manages how the the controller uses information

    public float inputBurnout;
    public float maxVelocity;

    public PlayerMotor motor;
    float xPerc = 0f;
    float yPerc = 0f;
    Vector3 input;
    private void FixedUpdate()
    {
       xPerc = Mathf.Lerp(xPerc,Input.GetAxisRaw("Horizontal"),inputBurnout*Time.deltaTime);
       yPerc = Mathf.Lerp(yPerc, Input.GetAxisRaw("Vertical"), inputBurnout*Time.deltaTime);

        //Vector3 input = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        input = Vector3.ClampMagnitude(new Vector3(xPerc, 0, yPerc), maxVelocity);
       

        motor.AddForce(input);

        
        motor.Gravity();

        motor.FinalMovement();


        motor.CalculateCollisions();




        motor.SlopeCalculation(motor.currentGround);

        motor.CorridorDetection();


    

        motor.ClampToGround(transform.TransformDirection(motor.f));

     //   motor.GroundCheck();



        motor.Jump();

        


    }

}
