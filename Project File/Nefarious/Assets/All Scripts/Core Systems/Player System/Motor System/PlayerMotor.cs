using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    /*
     * Calculating FOOT IK
     * Walking along walls calculate HAND IK
     * Procedurally affecting the bumper sphere
     * Making sure the player traverses complicated terrains smoothly
     */
	
    #region Variables

    #region Base Public Variables

    [Header("Main General Settings")]
    public bool displayGizmos;
    public float playerHeight;
    public float playerWidth;
    public float currentMass = 1;

    [Header("Movement Settings")]
    public float globalMovementSpeed;
    public float axisMovementSpeed;

    [Header("Slopes")]
    public float slopeLimit;
    public float slopeLimitModifier;

    [Header("Local Player Points")]
    [Header("Bumper Sphere")]
    public Vector3 bumperSpherePoint;
    public float bumperSphereRadius;

    [Header("Lift Sphere")]
    public Vector3 liftSpherePoint;
    public float liftSphereRadius;

    [Header("Physics Variables")]
    [Header("Gravity Variables")]
    public float gravityPower;
    public float gravityMultiplier;

    [Header("Layermask Variables")]
    public LayerMask discludePlayer;

    [Header("Jumping Variables")]
    public float jumpHeight;

    [Header("States")]
    public bool grounded;
    public enum PlayerState {GroundedMoving, SlidingSlope, Jumping, FixingError, AbsoluteStill, CollisionMoving};


    #endregion

    #region Physically Private Variables

    private Vector3 currentMovementVelocity;
    private Vector3 vel;


    #endregion

    #endregion


    //TODO : READ ALL COMMENTS!

    #region Code

    //Everything will be placed here properly
    //Using multithreading to make different events like Collisoin and Error Checking work together :)

    private void Update()
    {
        //Run Final Movement + Gravity Amongst other neccesities.. 

    }

    private float cGravMultiplier;
    //Change based on mass
    //TODO: If the ground is only a little bit below then decrease the gravity.
    public void Gravity() {
        if (!grounded) {
            vel.y -= gravityPower*cGravMultiplier;
            cGravMultiplier += gravityMultiplier;
        }
        else {
            cGravMultiplier = 1;
        }
    }

 
    private void FinalMovement() {
        //Calculate the movement 
        //Calculate current velocity
        //Change the bumper sphere position
    }


    public void AddForce(Vector3 force) {

        //! Normalise the values !//
        //Change based on mass
        //Calculate Collisions
        //Corridor Trapping
        //Ground calculation (Future based)
        //Slope traversing
        //Future clamping to ground etc...


    }

    public void Jump (float force) {
        //Calculate roof position
        //Holding jump will escalate the jump height
        //Switch state make sure no clamping occurs
        //Jump and add jump fall multiplier (enable gravity)
        //Change based on mass
    }

    private void SlopeCalculation (RaycastHit groundPoint) {
        //Check if slope is too high
        //Everytime it is add more pressure to moving upward
        //If maximum pressure threshold is reached then begin sliding downward.
        //Change based on mass
    }

    private void CorridorDetection () {
        //Make sure corridors are detected and the closer we get to stopping the slower we get
        //Make sure we are not clamping towards the ground...
    }

    private void CalculateGround (Vector3 position) {
        //Shoot a ray from forward point downwards
        //Check groundedness based on ray and sphere check in area
        //Check the state to make sure you can be grounded
    }

    private void ClampToGround (RaycastHit hit) {
        //Clamp to the future ground and make it work like that
        //Check if the ground is higher than the stair if not, then
        //Lerp onto the stair, not through the stair..
        //Stair movement and dropping
        //Smoothening movement
    }

    private void CalculateCollisions() {
        //Prevent going through the ground
        //Smooth
    }

    //Done after the final movement stage
    private void ErrorCalculation() {
        //Check if the player is stuck
        //Is going through a wall or ground
        //Go back to the original state
        //Check if you are vibrating... and smooth that down
        //Check if you are stuck between something
    }

    #endregion




}
