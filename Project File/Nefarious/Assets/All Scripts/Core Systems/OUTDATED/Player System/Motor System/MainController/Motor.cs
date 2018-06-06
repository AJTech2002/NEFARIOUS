using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour {

    #region Public Variables

    [Header("Attachments")]
    public Rigidbody rBody;
    public Transform cameraTransform;

    [Header("Slope Options")]
    public float maxSlope;
    public float maxSlippingSlope;
    public float slopeMultipler;

    [Header("General Options")]
    public float playerHeight;
    public float globalSpeed;
    public float liftCutoff;
    public float maxCollisionSlopeCheck;

    [Header("Physics/Collisions")]
    public LayerMask discludePlayerMask;
    public LayerMask discludeMinimumSlopes;
    public float simulatedGravity;

    [Header("LiftOptions")]
    public float liftSphereRadius;
    public Vector3 localListSpherePoint;
    public float liftSpeed;
    public float maxDropDist;

    [Header("Jumping Variables")]
    public float jumpForce;
    public float incrementJumpFallSpeed;
    public float jumpDecrease;

    [Header("Gizmos Options")]
    public bool drawGizmos;

    public enum GroundState {General,ClimbingStairs,RoughTerrain};
    [HideInInspector]
    public GroundState cGS;

    public enum PlayerState {Walking, Jumping, Running, Slipping};
    [HideInInspector]
    public PlayerState cPS;

    #endregion

    #region Private Variables

    [HideInInspector]
    public RaycastHit currentGround;
    [HideInInspector]
    public Vector3 finalVelocity;
    [HideInInspector]
    public bool grounded;
    [HideInInspector]
    public bool sphereGrounded;


    //CONTROL OPTIONS
    public Controller externalController;
    public bool externalControl = false;

    #endregion

    #region Main Movement / Methods

    


    //Preserve the movement even on slow computers by attaching frame independent movement
    private void FixedUpdate()
    {
        if (!externalControl)
        {
            HitTheGround();
            CheckGrounded();

            IdentifyGround();


            

            Jump(false);

            
            FakeInput();
            SlipDownSlope();

            if (cPS != PlayerState.Jumping)
            {
                ApplyGravity(true);
                CheckLift();
            }

            // SlopeCalculation();

            

            CalculateRawMovement();
        }
        else
        {
            externalController.ExternalFixedUpdate();
        }

    }

    private void Update()
    {
        if (!externalControl)
            Jump(true);
        else
            externalController.ExternalUpdate();
        
    }

    

    public void FakeInput()
    {
        if (cPS != PlayerState.Slipping)
        {
            Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            input = Vector3.ClampMagnitude(input, 1);
            finalVelocity += (input * globalSpeed);

        }
    }

    
    public void CalculateRawMovement()
    {

        if (cPS != PlayerState.Slipping)
        {
            Vector3 v = transform.TransformDirection(finalVelocity);
            //Vector3 v = cameraTransform.TransformDirection(finalVelocity);

            rBody.velocity = new Vector3(v.x, v.y, v.z);

            v.y = 0;
          

            finalVelocity = Vector3.zero;
        }
    }

    #endregion

    #region Grounding
    public void HitTheGround()
    {
        Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y + playerHeight / 2, transform.position.z), -transform.up*20);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, discludePlayerMask))
        {
            currentGround = hit;
        }

        return;

    }

    public void CheckGrounded()
    {
        sphereGrounded = Physics.CheckSphere(transform.TransformPoint(localListSpherePoint), liftSphereRadius, discludePlayerMask);

        if (currentGround.distance >= playerHeight)
        {
            grounded = false;
        }
        else if (currentGround.distance < playerHeight)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
    #endregion

    #region Life Savers

    private float timeOnSlope;
    private float afterHold;
    public float increaseMultiplier;
    private float coolDown = 0.13f;
    private Vector3 lastNorm;
    private Vector3 lastNorm2;
    public void SlipDownSlope()
    {
        
        
        
        Ray ray = new Ray(bottomPoint()+new Vector3(0,liftCutoff),transform.TransformDirection(finalVelocity));
        RaycastHit hit;

      

        if (Physics.Raycast(ray, out hit, maxCollisionSlopeCheck, discludeMinimumSlopes))
        {
            if (hit.transform.CompareTag("ControllerObject"))
                return;

            float slope = Vector3.Angle(hit.normal, Vector3.up);
            Vector3 hitNormal = hit.normal;
            Vector3 moveDirection = new Vector3(hitNormal.x, -hitNormal.y * 0.5f, hitNormal.z);
         
            if (slope > maxSlope)
            {
                if (currentGround.transform == hit.transform && currentGround.normal == hit.normal || cPS == PlayerState.Jumping)
                {
                    
                   
                }
                else
                {
                    if (hit.distance <= 1.5f)
                    {
                        finalVelocity *= Mathf.Clamp01(hit.distance-0.5f);
                       // axisPower = hit.distance;
                        
                    }
                    
                }
                //Debug.DrawRay(ray.origin, ray.direction, Color.red, 0.5f);
            }
            else
            {
              
                
            }

        }
        else
        {
     
        }


        Ray sphereRay = new Ray(topPoint(), -transform.up);
        RaycastHit curGround;

        if (Physics.SphereCast(sphereRay, 0.5f, out curGround, 5f, discludeMinimumSlopes))
        {
            if (curGround.transform.CompareTag("ControllerObject"))
                return;
            float currentSlope = Vector3.Angle(curGround.normal, Vector3.up);
            if (currentSlope > maxSlope && currentSlope < maxSlippingSlope)
            {
                if (cPS != PlayerState.Jumping)
                {
                    cPS = PlayerState.Slipping;

                    Vector3 hitNormal = curGround.normal;
                    Vector3 moveDirection = new Vector3(hitNormal.x, -hitNormal.y * 0.5f, hitNormal.z);
                    moveDirection *= 0.04f + timeOnSlope;

                    transform.position += moveDirection * 0.15f;
                    cPS = PlayerState.Slipping;

                    lastNorm = moveDirection * 0.15f;
                    timeOnSlope += Time.deltaTime;

                    coolDown = 0.23f;

                }
            }
            else
            {
                if (coolDown == 0.23f)
                {
                    coolDown = 0f;
                    cPS = PlayerState.Walking;
                    lastNorm.y = 0;
                    //transform.position += lastNorm * 2;
                    timeOnSlope = 0f;
                    lastNorm = Vector3.zero;
                }
            }

        }
        else
        {
            if (cPS == PlayerState.Slipping)
                cPS = PlayerState.Walking;
        }
  }

    #endregion

    #region Physics Simulations

    public void ApplyGravity(bool groundCheck)
    {
        if (!grounded && !sphereGrounded || !groundCheck)
        {
            if (cGS != GroundState.ClimbingStairs )
            finalVelocity.y += -simulatedGravity;
            //Apply gravity
        }
    }

    #region Jumping

    private string jumpPhase = "None";
    private float jumpHeight;
    private float fallMultiplier = -1f;
    private float startY;
    private bool activado = false;
    private bool isjumping;
    public void Jump(bool isUpdate)
    {

        if (isUpdate)
        {
            if (Input.GetKeyDown(KeyCode.Space) && (grounded || sphereGrounded) && cPS != PlayerState.Slipping)
            {

                cPS = PlayerState.Jumping;
                isjumping = true;
                jumpHeight += jumpForce;
                startY = transform.position.y;
                return;
            }
        }
        else
        {
            if (cPS == PlayerState.Jumping || isjumping)
            {
                jumpHeight -= (jumpHeight * jumpDecrease * Time.deltaTime) + fallMultiplier * Time.deltaTime;
                fallMultiplier += incrementJumpFallSpeed;

                finalVelocity.y = jumpHeight;


                //if ((transform.position.y - startY) > 0.6f)
                if (activado == false && !sphereGrounded)
                    activado = true;

                if (activado && (grounded || sphereGrounded))
                {
                    jumpHeight = 0;
                    fallMultiplier = -1;
                    startY = transform.position.y;
                    cPS = PlayerState.Walking;
                    isjumping = false;
                    activado = false;
                    CheckLift();
                }



            }

        }



    }

    #endregion

    public void CheckLift()
    {

        Ray ray = new Ray(topPoint(), -transform.up);
        RaycastHit hit;

        

        if (Physics.SphereCast(ray,liftSphereRadius,out hit,maxDropDist,discludePlayerMask))
        {
            float yDif = Mathf.Abs(hit.point.y - bottomPoint().y) * 100;
            float slope = Vector3.Angle(hit.normal, Vector3.up);

            if (hit.point.y < transform.position.y + liftCutoff)
            {

                if (sphereGrounded && cGS == GroundState.General)
                {

                    grounded = true;

                    //EXCEPTION: This behaviour will change on stairs (this is an inbuilt function that will trigger when the object's tag is 'StairObject'
                    if (yDif < 7f || cPS == PlayerState.Slipping)
                        rBody.position = Vector3.Lerp(rBody.position, new Vector3(rBody.position.x, hit.point.y + playerHeight / 2, rBody.position.z), 1f);
                    else
                    {
                        rBody.position = Vector3.Lerp(rBody.position, new Vector3(rBody.position.x, hit.point.y + playerHeight / 2, rBody.position.z), 0.52f);
                    }

                }
                else if (cGS == GroundState.ClimbingStairs || cGS == GroundState.RoughTerrain)
                    rBody.position = Vector3.Lerp(rBody.position, new Vector3(rBody.position.x, hit.point.y + playerHeight / 2, rBody.position.z), 0.25f);

            }

        }
        
    }

    #endregion

    #region State Machine

    private void IdentifyGround()
    {

        

        if (currentGround.transform.CompareTag("StairObject"))
        {
            cGS = GroundState.ClimbingStairs;
            return;
        }

        if (currentGround.transform.CompareTag("RoughTerrain"))
        {
            cGS = GroundState.RoughTerrain;
            return;
        }

        

        cGS = GroundState.General;
        return;

    }

    void OnTriggerEnter(Collider collider)
    {
        if (externalControl == false)
        {
            if (collider.transform.CompareTag("ControllerObject")) // this string is your newly created tag
            {
                collider.transform.GetComponent<Controller>().Attach();
            }
        }

    }


    #endregion

    #region Helper Methods


    public void OnDrawGizmos()
    {
        if (drawGizmos)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.TransformPoint(localListSpherePoint), liftSphereRadius);
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(bottomPoint() + new Vector3(0, liftCutoff), new Vector3(1,0.05f,1));
        }

    }

    public Vector3 bottomPoint ()
    {

        return new Vector3(transform.position.x, transform.position.y - playerHeight / 2, transform.position.z);

    }

    public Vector3 bottomPointFrom(Vector3 tPoint)
    {

        return new Vector3(tPoint.x, tPoint.y - playerHeight / 2, tPoint.z);

    }

    public Vector3 topPoint()
    {
        return new Vector3(transform.position.x, transform.position.y + playerHeight / 2, transform.position.z);
    }

    #endregion

}
