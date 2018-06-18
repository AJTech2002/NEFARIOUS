using UnityEngine;
using System.Collections;
using IK;

namespace IK
{
    public class FootIK : MonoBehaviour
    {
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

        private void LateUpdate()
        {
            Ray ray = new Ray(transform.position + Vector3.up * 2, Vector3.down);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, 10, mask))
            {
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
                }
            }

        }

    }
}