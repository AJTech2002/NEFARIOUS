using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AJTech.Management;
using AJTech.AI;


namespace AJTech.AI {
    public class SensoryManager : MonoBehaviour {

        [Header("Options")]
        public bool drawGizmos;

        public VisualInformation visualInformation;



        private void OnDrawGizmos()
        {
            if (drawGizmos)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(transform.position, visualInformation.radius);

                Vector3 fovLine1 = Quaternion.AngleAxis(visualInformation.fov, transform.up) * transform.forward * visualInformation.radius;
                Vector3 fovLine2 = Quaternion.AngleAxis(-visualInformation.fov, transform.up) * transform.forward * visualInformation.radius;

                Gizmos.color = Color.blue;
                Gizmos.DrawRay(transform.position, fovLine1);
                Gizmos.DrawRay(transform.position, fovLine2);

                if (!visualInformation.isInFov)
                    Gizmos.color = Color.red;
                else
                    Gizmos.color = Color.green;
                Gizmos.DrawRay(transform.position, (visualInformation.target.position - transform.position).normalized * visualInformation.radius);

                Gizmos.color = Color.black;
                Gizmos.DrawRay(transform.position, transform.forward * visualInformation.radius);
            }
        }

        private Transform t;
        private void Awake()
        {
            t = transform;
        }

        private void Update()
        {
            visualInformation.Find();
        }

    }

    [System.Serializable]
    public class VisualInformation
    {
        [Header("Vars")]
        public BehaviourProfile target;
        public Transform thisTransform;

        public float visibility;

        [Header("Field Of View")]
        public float radius;
        public float fov;
        public bool isInFov;
        public float peripharyFov;

        public void Find()
        {
           isInFov = inFOV(thisTransform, target, fov, radius);
        }

        public bool inFOV(Transform checkingObject, BehaviourProfile target, float maxAngle, float maxRadius)
        {

            //Collider[] overlaps = new Collider[10];
            //int count = Physics.OverlapSphereNonAlloc(checkingObject.position, maxRadius, overlaps);

            
            Vector3 directionBetween = (target.position - checkingObject.position).normalized;
            directionBetween.y *= 0;

            if ((target.position - checkingObject.position).magnitude <= maxRadius)
            {
                float angle = Vector3.Angle(checkingObject.forward, directionBetween);

                if (angle <= maxAngle)
                {
                    bool ret = false;
                    float s = 0f;
                    int r = 0;
                    for (int i = 0; i < target.accessPoints.Count; i++)
                    {
                        r++;
                        Ray ray = new Ray(checkingObject.position, target.t.TransformPoint(target.accessPoints[i]) - checkingObject.position);
                        RaycastHit hit;
                       
                        if (Physics.Raycast(ray, out hit, maxRadius))
                        {
                            
                            if (hit.transform == target.t)
                            {
                                ret = true;
                                s += 1;
                            }

                        }
                   

                    }
                    s /= r;
                    visibility = s;

                    if (ret == true)
                    return ret;


                }
            }

            visibility = 0f;
            return false;
        }
    }

}