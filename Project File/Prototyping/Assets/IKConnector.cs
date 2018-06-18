using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

namespace IK
{
    public class IKConnector : MonoBehaviour
    {

        public bool autoSolve;
        public bool solveForHand;
        public IKChain arm1;
        public IKChain arm2;

        [Header("Child Component")]
        public IKModelLookAt checkLookAt;
        public IKConnector childConnector;
        public bool hasChild;

        public float childInfluence;
        private float childDistance;

        public float rootSpeed;

        public SphericalConstraint constraint;

        private void Awake()
        {
            if (hasChild)
            childDistance = Vector3.Distance(childConnector.transform.position, transform.position);
        }

        private void LateUpdate()
        {
            if (autoSolve)
            SolveIK();
        }

        public void SolveIK()
        {

        

            Vector3 arm1V = arm1.SolveBackward(arm1.endEffector.position);
            Vector3 arm2V = arm2.SolveBackward(arm2.endEffector.position);
            
            Vector3 centroid = (arm1V + arm2V) / 2;
            if (hasChild)
                centroid += ((childConnector.transform.position + (transform.position - childConnector.transform.position).normalized * childDistance * childInfluence))/2;

            centroid = constraint.clampIfNeeded(centroid);

            arm1.SolveForward(centroid);
            arm2.SolveForward(centroid);

            transform.position = centroid;

            arm1.SetTempPos();
            arm2.SetTempPos();

            if (hasChild && autoSolve)
                childConnector.SolveIK();

            if (checkLookAt != null)
            {
                checkLookAt.SolveModel();
                arm1.SetModelPosition();
                arm2.SetModelPosition();
            }

            if (solveForHand)
            {
                arm1.SolveForEndPoint();
                arm2.SolveForEndPoint();
            }

        }

        public void SolveArm1(IKChain arm1)
        {


            Vector3 arm1V = arm1.SolveBackward(arm1.endEffector.position);
           

            arm1.SolveForward(transform.position);
             
            arm1.SetTempPos();
          
        }

    }
}