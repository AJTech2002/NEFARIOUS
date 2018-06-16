using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IK;
public class LocomotionSystem : MonoBehaviour {

    public Transform footA;
    public Transform realFoot;
    public Transform footIKA;
    public Vector3 footOffset;
    public float footLift;
    public float maxDIst;
    public Animator affectBlending;
    public IKConnector solver;
    public float closes;
	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame

    public string leg;

	void LateUpdate () {
     
            Ray ray = new Ray(footA.position, Vector3.down);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.distance <= maxDIst)
                {
                    Vector3 hp = hit.point;
                    hp.y += footLift;

                    footIKA.position = Vector3.Lerp(footIKA.position, hp, 0.6f);
                    realFoot.LookAt(realFoot.position + footIKA.forward * 10, footIKA.right);
                    realFoot.Rotate(footOffset);
                    if (leg == "right")
                        solver.SolveArm1(solver.arm1);
                    else
                        solver.SolveArm1(solver.arm2);
                    
                    //  affectBlending.SetLayerWeight(1, 1f);
                }
                else
                {
                    //  affectBlending.SetLayerWeight(1, 0f);
                }
            }
       
	}

    public void SolveIKFor (string legName)
    {
        leg = legName;
    }

}
