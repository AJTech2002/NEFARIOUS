using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IK;

public class IKContactsSystem : MonoBehaviour {

    [Header("References")]
    public Transform toeL;
    public Transform toeR;
    public Transform leftIK;
    public Transform rightIK;
    public IKChain rChain;
    public IKChain lChain;

    [Header("Spherical Collider Offsets")]
    public Vector3 leftOffset;
    public Vector3 leftSize;
    public Vector3 rightOffset;
    public Vector3 rightSize;

    [Header("Conditionals")]
    public bool toeContactAchievedL;
    public bool toeContactAchievedR;

    [Header("Layermask")]
    public LayerMask discludePlayer;

    [Header("Tweakables")]
    public AnimationCurve footBlending;
    public float LeftMaxDist;
    public float RightMaxDist;

    private void OnDrawGizmos()
    {
        if (toeContactAchievedL)
            Gizmos.color = Color.green;
        else
            Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(toeL.position + leftOffset, leftSize.x);

        if (toeContactAchievedR)
            Gizmos.color = Color.green;
        else
            Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(toeR.position + rightOffset, rightSize.x);

        Gizmos.color = Color.black;
        foreach (Vector3 v in leftContacts)
        {
            Gizmos.DrawWireSphere(v, 0.05f);
        }

        foreach (Vector3 v in rightContacts)
        {
            Gizmos.DrawWireSphere(v, 0.05f);
        }

        

    }

    private void FixedUpdate()
    {/*
        MakePrediction();
      
        CheckFeetContacts();

        MakePercentageChecks();

        CalculateVelocity();
        CalculateAverageStrideDistance();
        */
        Vector3 p = rayHit(transform.position+rightOffset, Vector3.down, 5, discludePlayer).point;
        Vector3 p2 = rayHit(transform.position+leftOffset, Vector3.down, 5, discludePlayer).point;

        leftIK.position = p2;
        rightIK.position = p;

    }

    private List<Vector3> leftContacts = new List<Vector3>();
    private List<Vector3> rightContacts = new List<Vector3>();

    //[Header("Non-Exposed Variables")]
    private float leftStrideSize;
    private float rightStrideSize;
    private Vector3 currentVelocity;

    private Vector3 lastPosition;

    private Vector3 predictedLeft;
    private Vector3 predictedRight;


    private void MakePercentageChecks()
    {
        float lPerc = 0f;
        float rPerc = 0f;

        Vector3 pL = rayHit(toeL.position + leftOffset, Vector3.down, 5, discludePlayer).point;
        float distL = (Vector3.Distance(pL, predictedLeft));
        if (distL <= LeftMaxDist)
        lPerc = Mathf.Clamp(distL / LeftMaxDist,0f,1f); 

        Vector3 pR = rayHit(toeR.position + rightOffset, Vector3.down, 5, discludePlayer).point;
        float distR = (Vector3.Distance(pR, predictedRight));
        if (distR <= RightMaxDist)
        rPerc = Mathf.Clamp(distR / RightMaxDist,0f,1f);

        lPerc = footBlending.Evaluate(lPerc);
        rPerc = footBlending.Evaluate(rPerc);

        rChain.doubleBlend = rPerc;
        lChain.doubleBlend = lPerc;

       // print("Left Perc : " + lPerc + " --- " + " Right Perc : " + rPerc);

    }

    private void MakePrediction()
    {
        if (rightContacts.Count > 0 && leftContacts.Count > 0)
        {
            Vector3 r = rightContacts[rightContacts.Count - 1] + (currentVelocity.normalized * rightStrideSize) + Vector3.up;
            Vector3 l = leftContacts[leftContacts.Count - 1] + (currentVelocity.normalized * leftStrideSize) + Vector3.up;

            predictedRight = rayHit(r, Vector3.down, 20, discludePlayer).point;
            predictedLeft = rayHit(l, Vector3.down, 20, discludePlayer).point;

            Debug.DrawLine(r, predictedRight, Color.magenta);
            Debug.DrawLine(l, predictedLeft, Color.magenta);

            leftIK.position = predictedLeft;
            rightIK.position = predictedRight;
        }
    }

    private void CalculateVelocity()
    {
        currentVelocity =(transform.position - lastPosition) / Time.deltaTime;
        lastPosition = transform.position;
    }
   
    private void CheckFeetContacts()
    {
        if (Physics.CheckSphere(toeL.position + leftOffset, leftSize.x, discludePlayer))
        {
            if (toeContactAchievedL == false)
            {
                toeContactAchievedL = true;
                Vector3 p = rayHit(toeL.position + leftOffset, Vector3.down, 5, discludePlayer).point;
                leftContacts.Add(p);
               // print("Left Accuracy : " + (Vector3.Distance(p, predictedLeft)));
                if (leftContacts.Count > 3)
                {
                    leftContacts.RemoveAt(0);
                }
            }
        }
        else
        {
            toeContactAchievedL = false;
        }

        if (Physics.CheckSphere(toeR.position + rightOffset, leftSize.x, discludePlayer))
        {
            if (toeContactAchievedR == false)
            {
                toeContactAchievedR = true;
                Vector3 p = rayHit(toeR.position + rightOffset, Vector3.down, 5, discludePlayer).point;
                rightContacts.Add(p);
             //   print("Right Accuracy : " + (Vector3.Distance(p, predictedRight)));
                if (rightContacts.Count > 3)
                {
                    rightContacts.RemoveAt(0);
                }
            }
        }
        else
        {
            toeContactAchievedR = false;
        }
    }

    private void CalculateAverageStrideDistance()
    {
            leftStrideSize = 0f;
            rightStrideSize = 0f;

            for (int i = 0; i < leftContacts.Count; i++)
            {
                if (i == 0)
                    continue;

                leftStrideSize += Vector3.Distance(leftContacts[i], leftContacts[i - 1]);

            }
            leftStrideSize /= leftContacts.Count;
            for (int i = 0; i < rightContacts.Count; i++)
            {
                if (i == 0)
                    continue;

                rightStrideSize += Vector3.Distance(rightContacts[i], rightContacts[i - 1]);

            }
            rightStrideSize /= rightContacts.Count;

    }

    private RaycastHit rayHit(Vector3 origin, Vector3 direction, float maxDist, LayerMask layerMasks)
    {
        RaycastHit hit;
        Ray ray = new Ray(origin, direction);

        Physics.Raycast(ray, out hit, maxDist, layerMasks);
        
        return hit;
    }

}

