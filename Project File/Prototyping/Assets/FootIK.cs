using UnityEngine;
using System.Collections;
using System;
using IK;

namespace IK
{
    public class FootIK : MonoBehaviour
    {

        public Animator anim;
        public Transform foot;
        public Vector3 fotOffset;
        [Header("Animation Curves")]
        public AnimationCurve blendCurve;
        public AnimationCurve doubleBlendCurve;
     
        [Range(0, 1)]
        public float blendPowerIncrease;
        [Range(0, 1)]
        public float blendPowerDecrease;
        [Range(0, 1)]
        public float movementInterpolation;
        public LayerMask mask;
        public IKChain blendingFoot;
        public Transform shinBOne;
        private bool touchingTheGround;
        public float hitProximity;
        private Vector3 hitPoint;
        public float powpow;
        [Header("A")]
        public Vector3 footOffset;

        private void OnDrawGizmos()
        {
            if (touchingTheGround)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireCube(hitPoint, new Vector3(1, 0.4f, 1f));
            }
        }

        private float timer;
        private void LateUpdate()
        {

            

            Ray ray = new Ray(transform.position+ Vector3.up * 2, Vector3.down);
           // Debug.DrawRay(ray.origin, ray.direction,Color.red,0.2f);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, 10, mask))
            {
                /*
                if (hit.distance <= hitProximity)
                {
                    hitPoint = hit.point;
                    blendingFoot.blendSpeed = Mathf.Lerp(blendingFoot.blendSpeed, ((hit.distance / hitProximity)), blendPowerIncrease);
                    //blendingFoot.doubleBlend = Mathf.Lerp(blendingFoot.doubleBlend, ((hit.distance / hitProximity)), blendPowerIncrease);
                    transform.position = Vector3.Lerp(shinBOne.position, hit.point, (hit.distance / hitProximity)*powpow);
                    touchingTheGround = true;
                }
                else
                {
                    touchingTheGround = false;
                    blendingFoot.blendSpeed = Mathf.Lerp(blendingFoot.blendSpeed, 0f, blendPowerDecrease);
                    //blendingFoot.doubleBlend = Mathf.Lerp(blendingFoot.doubleBlend, 0f, blendPowerDecrease);
                    transform.position = Vector3.Lerp(transform.position, shinBOne.position, movementInterpolation);
                }*/
                timer += Time.deltaTime;
           
                float hitPercentage = timer/anim.GetCurrentAnimatorStateInfo(1).length;
                print(hitPercentage);
                //float hitPercentage = Mathf.Clamp((hit.distance) / hitProximity, 0, 1);
                float blendPerc = blendCurve.Evaluate(hitPercentage);
                float doublePerc = doubleBlendCurve.Evaluate(hitPercentage);
                transform.position = hit.point+footOffset;
                blendingFoot.blendSpeed = Mathf.Lerp(blendingFoot.blendSpeed,blendPerc,blendPowerIncrease);
                blendingFoot.doubleBlend = Mathf.Lerp(blendingFoot.doubleBlend,doublePerc,blendPowerDecrease);
                Vector3 cross = Vector3.Cross(hit.normal, transform.right);
                Vector3 crossR = Vector3.Cross(cross, hit.normal);
                Debug.DrawLine(transform.position, transform.position-cross*100, Color.green, 0.2f);

                foot.LookAt(transform.position - cross * 100, Vector3.right);
                foot.Rotate(fotOffset);

                if (timer >= anim.GetCurrentAnimatorStateInfo(1).length)
                    timer = 0f;

                /*
                if (hit.distance <= hitProximity)
                {
                    float hitPercentage = Mathf.Clamp((hit.distance) / hitProximity, 0, 1);
                    float blendPerc = blendCurve.Evaluate(hitPercentage);
                    float doublePerc = doubleBlendCurve.Evaluate(hitPercentage);
                    transform.position = Vector3.Lerp(shinBOne.position, hit.point, movementInterpolation);
                    blendingFoot.blendSpeed = blendPerc;
                    blendingFoot.doubleBlend = doublePerc;
                    touchingTheGround = true;
                    print(transform.name + " Hit perc " + hitPercentage);

                }
                else
                {
                    blendingFoot.blendSpeed = Mathf.Lerp(blendingFoot.blendSpeed, 0f, blendPowerDecrease);
                    blendingFoot.doubleBlend = Mathf.Lerp(blendingFoot.blendSpeed, 0f, blendPowerDecrease);
                    transform.position = Vector3.Lerp(transform.position, shinBOne.position, movementInterpolation);
                    touchingTheGround = false;
                }
                */
            }

        }
    }
}