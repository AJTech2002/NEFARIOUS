using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IK;
public class LocomotionSystem : MonoBehaviour {

    [Header("Head IK")]
    public Transform headBone;
    public Vector3 headOffset;

    [Header("Arms and Legs")]
    public IKConnector armsConnector;
    public IKConnector legsConnector;

    [Header("Chest")]
    public IKModelLookAt chestConnector;

    [Header("External References")]
    public Animator playerAnimator;

    [Header("Preset Animator Curves")]
    public List<AnimationCurve> curves = new List<AnimationCurve>();

    [Header("LookTesting")]
    public float chest;

   


}
