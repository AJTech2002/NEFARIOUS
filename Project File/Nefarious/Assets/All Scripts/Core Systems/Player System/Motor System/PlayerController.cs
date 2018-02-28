using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //This controller manages how the the controller uses information

    public PlayerMotor motor;

    private void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));

        motor.AddForce(input);

        motor.Gravity();


        motor.FinalMovement();


        motor.CalculateCollisions();


        motor.SlopeCalculation(motor.currentGround);

        motor.CorridorDetection();

        motor.ClampToGround(transform.TransformDirection(motor.f));

      

        motor.Jump();


    }

}
