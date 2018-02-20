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
    public float futureGroundCheck = 0.01f;
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


    private void OnDrawGizmos()
    {
     
        Gizmos.color = Color.black;
        Gizmos.DrawSphere((transform.position) + (transform.up/2+(transform.forward*futureGroundCheck)),0.02f);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.TransformPoint(bumperSpherePoint),bumperSphereRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.TransformPoint(liftSpherePoint),liftSphereRadius);

    }

    //Everything will be placed here properly
    //Using multithreading to make different events like Collisoin and Error Checking work together :)

    private void LateUpdate()
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


    public void FinalMovement()
    {
        //Calculate the movement 
        //Calculate current velocity
        //Change the bumper sphere position
        //Friction and slow down speed over time

        Vector3 movementVel = new Vector3(vel.x, vel.y, vel.z);
        movementVel = transform.TransformDirection(movementVel);

        transform.position += movementVel * globalMovementSpeed;

        vel = new Vector3(0, 0, 0);

    }


    public void AddForce(Vector3 force) {

        /*! Normalise the values !//
        //Change based on mass
        //Calculate Collisions
        //Corridor Trapping
        //Ground calculation (Future based)
        //Slope traversing
        //Future clamping to ground etc... */

        Vector3 f = force;
        f *= axisMovementSpeed;

        //Clamp To The Ground #1
        ClampToGround(transform.TransformDirection(f));

        vel += f;


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
        /*Shoot a ray from forward point downwards
        //Check groundedness based on ray and sphere check in area
        //Check the state to make sure you can be grounded*/



    }


    //TODO : Change to just a RayCast
    //TODO : Use the step height to calculate weather you can climb up... or collide script activate :)

    private void ClampToGround (Vector3 vel) {
        /*Clamp to the future ground and make it work like that
        //Check if the ground is higher than the stair if not, then
        //Lerp onto the stair, not through the stair..
        //Stair movement and dropping
        //Smoothening movement*/

        Vector3 p = transform.TransformPoint(liftSpherePoint)+(vel*futureGroundCheck);
        RaycastHit[] hits = new RaycastHit[10];

        int count = Physics.SphereCastNonAlloc(p,liftSphereRadius,Vector3.zero,hits,playerHeight,discludePlayer);

        if (hits.Length > 0) {
            RaycastHit hitNeeded = hits[0];
            for (int i = 0;i < hits.Length; i++) {
                if (hits[i].point.y > hitNeeded.point.y) {
                    hitNeeded = hits[i];
                }    
            }

            transform.position = new Vector3(transform.position.x, hitNeeded.point.y+playerHeight/2, transform.position.z);

        }

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
