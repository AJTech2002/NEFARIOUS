using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IK;

public class RayBoxing : MonoBehaviour {

    [Header("References")]
    public Transform IKBONE;
    public Vector3 ikOffset;
    public Animator anim;
    public Transform RayTransform;
    public Transform foot;
    public Transform footTrans;
    public IKChain chain;

    [Header("Forward Prediction")]
    public Vector3 forward;
    public LayerMask avoidPlayer;

    [Header("Vars")]
    public Vector3 footBounder;
    public Vector3 footOffset;
    public Vector3 hitOffset;
    public Vector3 fotOffset;
    public Vector3 footHitOffset;

    private Vector3 predictedPoint;
    private Vector3 actualPoint;

    [Header("Animation Curves")]
    public AnimationCurve blendController;
    public float blendModifySpeed;

    [Header("Display")]
    [Range(0,1)]
    public float display;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(foot.position+footOffset, footBounder);

        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(RayTransform.TransformPoint(hitOffset), RayTransform.TransformPoint(hitOffset) + Vector3.down * 10);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(predictedPoint, 0.15f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(actualPoint, 0.15f);

    }

    float maxDist;

    private void LateUpdate()
    {
        Ray bottomRay = new Ray(foot.position+footHitOffset, Vector3.down);
        Ray futureRay = new Ray(RayTransform.TransformPoint(hitOffset), Vector3.down);
        RaycastHit bottomHit;
        RaycastHit futureHit;

        if (Physics.Raycast(bottomRay, out bottomHit, 20, avoidPlayer) && Physics.Raycast(futureRay, out futureHit, 20, avoidPlayer))
        {
            predictedPoint = futureHit.point;
            IKBONE.position = predictedPoint+ikOffset;   
            actualPoint = bottomHit.point;
            Debug.DrawLine(bottomRay.origin, bottomHit.point, Color.green);
            
            if (Vector3.Distance(actualPoint, predictedPoint) > maxDist)
            {
                maxDist = Vector3.Distance(actualPoint, predictedPoint);
            }

            float executionPercentage = Vector3.Distance(actualPoint, predictedPoint) / maxDist;

            display = (1-Mathf.Clamp(executionPercentage, 0f, 1f));
            float b = blendController.Evaluate(display);

            Vector3 cross = Vector3.Cross(futureHit.normal, transform.right);
            Vector3 crossR = Vector3.Cross(cross, futureHit.normal);
            Debug.DrawLine(IKBONE.position, IKBONE.position - cross * 100, Color.green, 0.2f);

            IKBONE.LookAt(IKBONE.position - cross * 100);

            //chain.blendSpeed = Mathf.Lerp(chain.blendSpeed, b, blendModifySpeed);
  

        }

            
    }

    


}
