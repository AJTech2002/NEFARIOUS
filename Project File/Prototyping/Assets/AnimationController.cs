using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEditor;
public class AnimationController : MonoBehaviour {

    public Motor motor;

    public Animator animator;
    public float lastX;
    public float lastZ;

    public Vector2 dampening;
   
    private Vector2 lastVelocity;

    public void VelocityChange(Vector3 velocity)
    {

        lastX = Mathf.Lerp(lastX, velocity.x, dampening.x);
        lastZ = Mathf.Lerp(lastZ, velocity.z, dampening.y);

       

       /* if (Mathf.Abs(lastVelocity.x - velocity.x) > 0.6f && Mathf.Abs(velocity.z) < 0.2f)
        {
           // print("SWITCHED");

            animator.SetFloat("pivotalThreshold", velocity.x-lastVelocity.x);
            animator.SetInteger("movementState", 2);
            motor.inputPower = 0f;
            lastVelocity = new Vector2(velocity.x, velocity.z);
            return;
        } */

        

        //motor.inputPower = Mathf.Clamp(Mathf.Lerp(motor.inputPower, 1f, 0.05f),0f,1f);

        if (Mathf.Abs(velocity.z) < 0.1f && Mathf.Abs(velocity.x) < 0.1f)
            animator.SetInteger("movementState", 0);
        else
            animator.SetInteger("movementState", 1);

        lastVelocity = new Vector2(velocity.x, velocity.z);

       


        animator.SetFloat("Forward", lastZ);
        animator.SetFloat("Right", lastX);
    }

}
