using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IK
{
    public class IKConnector : MonoBehaviour
    {
        public IKChain arm1;
        public IKChain arm2;

        public float rootSpeed;

        public SphericalConstraint constraint;

        private void LateUpdate()
        {
            SolveIK();
        }

        private void SolveIK()
        {


            Vector3 arm1V = arm1.SolveBackward(arm1.endEffector.position);
            Vector3 arm2V = arm2.SolveBackward(arm2.endEffector.position);

            Vector3 centroid = (arm1V + arm2V) / 2;

            centroid = constraint.clampIfNeeded(centroid);

            arm1.SolveForward(centroid);
            arm2.SolveForward(centroid);

            transform.position = centroid;

            arm1.SetTempPos();
            arm2.SetTempPos();

           

        }

    }
}