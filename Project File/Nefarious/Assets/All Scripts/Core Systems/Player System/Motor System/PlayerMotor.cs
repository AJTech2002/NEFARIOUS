 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    /*
     * Calculating FOOT IK
     * Walking along walls calculate HAND IK
     * Procedurally affecting the bumper sphere
     * Making sure the player traverses complicated terrains smoothly
     * TODO: USING ANIMATION CURVES FOR VELOCITIES!!!!
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
    public float climbingSpeeds;
    public float interpolationSpeed;
    public float stairClimbingSpeeds = 0.2f;

    [Header("Slopes")]
    public float futureGroundCheck = 0.01f;
    public float slopeLimit;
    public float impossibleSlope;
    public float slopeLimitModifier;

    [Header("Collision Attributes")]
    public Vector3 topCapsulePoint;
    public Vector3 bottomCapsulePoint;
    public float capsuleRadius;

    [Header("Local Player Points")]
    [Header("Bumper Sphere")]
    public SphereCollider bumperCollider;
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
    public float jumpForce;
    public float incrementJumpFallSpeed;
    public float jumpDecrease;

    [Header("States")]
    public bool grounded;
    private bool slippingDownSlope = false;
    public enum PlayerState {GroundedMoving, SlidingSlope, Jumping, FixingError, AbsoluteStill, CollisionMoving};


    #endregion

    #region Physically Private Variables

    private Vector3 currentMovementVelocity;
    private Vector3 vel;


    #endregion

    #endregion


    //TODO : Make sure that jump is based on time that you hold the jump.....

    //TODO : READ ALL COMMENTS!

    #region Code

    private void Awake()
    {
        axisPower = 1f;
    }

    #region Gizmos
    private void OnDrawGizmos()
    {
        if (displayGizmos)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawSphere((transform.position) + (transform.up / 2 + (transform.forward * futureGroundCheck)), 0.02f);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.TransformPoint(bumperSpherePoint), bumperSphereRadius);

            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.TransformPoint(liftSpherePoint), liftSphereRadius);

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.TransformPoint(topCapsulePoint), capsuleRadius);
            Gizmos.DrawWireSphere(transform.TransformPoint(bottomCapsulePoint), capsuleRadius);
        }

    }
    #endregion

    #region Gravity
    //Everything will be placed here properly
    //Using multithreading to make different events like Collisoin and Error Checking work together :)

    [HideInInspector]
    public Vector3 f = new Vector3(0,0,0);
    //[HideInInspector]
    public float currentSlopeModifier = 0;

    
    private float cGravMultiplier;
    //Change based on mass
    //TODO: If the ground is only a little bit below then decrease the gravity.

    public void Gravity() {
        if (!grounded) {
            vel.y -= (gravityPower)*cGravMultiplier;
            cGravMultiplier += gravityMultiplier;
        }
        else {
            cGravMultiplier = 1;
        }
    }

    #endregion

    #region Final Movement

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

    #endregion

    #region Add Force

    public void AddForce(Vector3 force) {

        /*! Normalise the values !//
        //Change based on mass
        //Calculate Collisions
        //Corridor Trapping
        //Ground calculation (Future based)
        //Slope traversing
        //Future clamping to ground etc... */

        //AXIS POWER for '1'

        axisPower = Mathf.Clamp(axisPower, 0, 1);
    //    print(axisPower);

        f = force;

        if (f != Vector3.zero)
            lastMovement = f;

        f *= axisMovementSpeed*axisPower;


      

       // f = CorridorDetection(lastMovement);


        //Clamp To The Ground #1


        vel += f;


    }

    #endregion

    #region Jumping

    private bool inputJump;
    bool canJump = false;
    private float fallMultiplier = -1f;
    private float jumpHeight;

    public void Jump () {
        //Calculate roof position
        //Holding jump will escalate the jump height
        //Switch state make sure no clamping occurs
        //Jump and add jump fall multiplier (enable gravity)
        //Change based on mass




        canJump = !Physics.Raycast (new Ray (transform.position, Vector3.up), playerHeight, discludePlayer);

        if (grounded && jumpHeight > 0.2f || jumpHeight <= 0.2f && grounded) {
            if (inputJump)
            {
                
            }

            jumpHeight = 0;
            inputJump = false;
            fallMultiplier = -1;

        }

        if (grounded && canJump && !slippingDownSlope) {

            if (Input.GetKeyDown(KeyCode.Space)){
                inputJump = true;
                transform.position += Vector3.up * 0.1f;
                gravModif = 1 ;
                jumpHeight += jumpForce;
            }

        } else {
            if (!grounded) {

                jumpHeight -= (jumpHeight * jumpDecrease * Time.deltaTime) + fallMultiplier * Time.deltaTime;
                fallMultiplier += incrementJumpFallSpeed;

            }
        }

        vel.y += jumpHeight;

    }

    #endregion

    #region Slope Calculation

    //SLOPE MODIFICATION VARIABLES

    float slopeTimer = 0f;
    Vector3 lastNormal = new Vector3(0, 0, 0);
    float coolDown = 0f;
    float axisPower = 0f;
    public RaycastHit currentGround;
    private bool lastGroundWasSlope;
    private RaycastHit lastSlope;
    private float lastTimer;

    public void SlopeCalculation (RaycastHit groundPoint) {

        //TODO: Add warm down timer so slope continues to slide
        //TOOD: Also make sure the normal is transformed to be in local sapce

        //Check if slope is too high
        //Everytime it is add more pressure to moving upward
        //If maximum pressure threshold is reached then begin sliding downward.
        //Change based on mass
       // axisPower = 1;
        float slope = Vector3.Angle(groundPoint.normal,Vector3.up);
        Vector3 hitNormal = groundPoint.normal;

        bool isGrounded = (Vector3.Angle(Vector3.up, hitNormal) <= slopeLimit);

        if (!isGrounded)
        {
            Vector3 moveDirection = new Vector3(hitNormal.x, -hitNormal.y, hitNormal.z);
            Vector3.OrthoNormalize(ref hitNormal, ref moveDirection);
            moveDirection *= 0.01f+slopeTimer;
            transform.position += moveDirection*0.1f;
            axisPower = 0F;
            slopeTimer += Time.deltaTime;

            slippingDownSlope = true;

            coolDown = 0.13f;

        }
        else
        {
          //  coolDown -= Time.deltaTime;
         
            slippingDownSlope = false;
            slopeTimer = 0f;
            axisPower = 1f;
            
        }

    }

    #endregion

    #region Corridor Detection Kinda
    private bool colliding = false;
    private Vector3 lastMovement;

    private bool slippingThroughGap = false;
    public void CorridorDetection () {

        RaycastHit hit;
        if (Physics.CapsuleCast(transform.TransformPoint(topCapsulePoint),transform.TransformPoint(bottomCapsulePoint),capsuleRadius, transform.TransformDirection(lastMovement),out hit, 5,discludePlayer)) {
            if (hit.distance <= capsuleRadius * capsuleRadius)
            {

                axisPower = 0.5f;
            }
            else
            {
                axisPower = 1f;
            }
        }
        else
        {
            axisPower = 1f;
        }

    }

    #endregion

    #region ClampToGround (IMPORTANT)

    //TODO : Change to just a RayCast
    //TODO : Use the step height to calculate weather you can climb up... or collide script activate :)

    private float gravModif;
    private Vector3 lastClampPosition = Vector3.zero;
    private float lastClimbSpeed = 1f;

    public void ClampToGround (Vector3 vel) {
        /*Clamp to the future ground and make it work like that
        //Check if the ground is higher than the stair if not, then
        //Lerp onto the stair, not through the stair..
        //Stair movement and dropping
        //Smoothening movement*/

        //TODO: Make sure that it is future checking

        //TODO: Make sure it is checking if it fell through the ground


        float ht = playerHeight+2f;

        if (inputJump) {
            ht -= 2f;
        }

        Vector3 point = transform.TransformPoint(transform.up/2+(lastMovement*futureGroundCheck));
        Ray ray = new Ray(point, Vector3.down);
        RaycastHit hit;

       

        //CHECK THE LAST POINT IT CLAMPED TOOO AND IF THIS IS DIST > 0.5 THEN LERP IT BOI (LOWER LERP)

        if (Physics.Raycast(ray, out hit, ht, discludePlayer)) {

            currentGround = hit;

            if (hit.point.y <= (transform.TransformPoint(liftSpherePoint).y+liftSphereRadius)) {
                Vector3 shouldBe = new Vector3(transform.position.x, hit.point.y + playerHeight/2, transform.position.z);
                float slope = Vector3.Angle(hit.normal, Vector3.up);
                float finalSpeed = lastClimbSpeed;
                bool canClimb = true;

                if (shouldBe.y > lastClampPosition.y)
                {
                    if (slope > slopeLimit)
                    {
                        if (slope > impossibleSlope)
                        {
                            axisPower -= 0.5f;
                        }
                        finalSpeed = Mathf.Lerp(finalSpeed, climbingSpeeds*0.9f, 0.2f);
                    }
                    else
                    {
                       // currentSlopeModifier = Mathf.Lerp(currentSlopeModifier, 0, Time.deltaTime * 2);
                        if ((shouldBe.y-lastClampPosition.y) > 0.08f && slope < 10)
                        {
                            finalSpeed = stairClimbingSpeeds;
                        }
                        else
                        {
                            finalSpeed = Mathf.Lerp(finalSpeed, climbingSpeeds * 0.9f, 0.4f);
                        }

                        //axisPower = Mathf.Clamp01(axisPower + 0.05f);
                        //currentSlopeModifier = 0;
                    }
                }
                else
                {
                    if (!Mathf.Approximately(shouldBe.y, lastClampPosition.y))
                    {
                        
                       if ((lastClampPosition.y - shouldBe.y) > 0.08f && slope < 10)
                        {
                            finalSpeed = stairClimbingSpeeds;
                        }
                       else
                        {
                            finalSpeed = Mathf.Lerp(finalSpeed, climbingSpeeds * 0.9f, 0.4f);
                        }

                    }

                    //currentSlopeModifier = Mathf.Lerp(currentSlopeModifier, 0, Time.deltaTime * 2);
                    //axisPower = Mathf.Clamp01(axisPower + 0.05f);
                   // currentSlopeModifier = 0;
                }

                lastClampPosition = shouldBe;
                lastClimbSpeed = finalSpeed;

                if (canClimb)
                {
                  if ((hit.point-transform.position).y < 0)
                    {
                        if (hit.distance > 2.5f)
                        {
                          //  Vector3 mP2 = new Vector3(transform.position.x, transform.position.y - playerHeight / 2, transform.position.z);
                           // Vector3 dir2 = shouldBe - mP2;
                           // transform.position = Vector3.Lerp(transform.position, transform.position + (dir2 * finalSpeed), interpolationSpeed);
                            grounded = false;
                            return;
                        }
                    }
               //  transform.position = Vector3.Lerp(transform.position, shouldBe, finalSpeed);
                Vector3 mP = new Vector3(transform.position.x, transform.position.y - playerHeight / 2, transform.position.z);
                Vector3 dir = shouldBe - mP;

                    if (inputJump)
                    {
                        finalSpeed = 1f;
                        transform.position = Vector3.Lerp(transform.position, transform.position + (dir * finalSpeed), interpolationSpeed);
                    }
                    else
                    {
                        transform.position = Vector3.Lerp(transform.position, transform.position + (dir * finalSpeed), interpolationSpeed);
                    }
                    //axisPower = 1f;
                }

            }
           // SlopeCalculation(hit);

            grounded = true;

        }
        else {
            grounded = false;
        }

    }

    #endregion

    #region Collision Calculation

    public void CalculateCollisions() {
        //Prevent going through the ground
        //Smooth

        Collider[] colliders = new Collider[4];

        //Query Trigger Interaction = Ignore so if any errors fix this
        int count = Physics.OverlapSphereNonAlloc(transform.TransformPoint(bumperSpherePoint),bumperSphereRadius,colliders, discludePlayer, QueryTriggerInteraction.Ignore);

        for (int i = 0; i < count; i++) {

            Collider a = bumperCollider;
            Collider b = colliders[i];

            float dist;
            Vector3 dir;

            if (Physics.ComputePenetration(a, transform.position, transform.rotation, b, b.transform.position, b.transform.rotation, out dir, out dist))
            {

                Vector3 penetrationVector = dir * dist;
                Vector3 velocityProjected = Vector3.Project(vel, -dir);
                transform.position = transform.position + penetrationVector;
                vel -= velocityProjected;

                colliding = true;


            }
            else
            {
                colliding = false;

            }

        }



    }

    #endregion

    #region Error Calculatoin

    //Done after the final movement stage
    private void ErrorCalculation() {
        //Check if the player is stuck
        //Is going through a wall or ground
        //Go back to the original state
        //Check if you are vibrating... and smooth that down
        //Check if you are stuck between something
    }

    #endregion


    #endregion 

}

