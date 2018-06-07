using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitController : MonoBehaviour {

    [Header("General Options")]
    public Transform playerTarget;
    public Camera cam;
    public float distanceFromTarget;
    public Vector3 offsetOrbitPoint;

    [Header("Speeds")]
    public float followLag;
    public float rotationSpeed;
    public float cameraSpeed;

    public float clampMax;

    public Vector2 sensitivity;
    public Vector2 pitchMinMax;

    [Header("While Moving")]
    public float fovAdd = 5;
    public float distanceAdd = 1;

    #region Privates
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    float yaw;
    float pitch;
    #endregion


    private float originalFOV;
    private float originalDist;
    private void Awake()
    {
        originalFOV = cam.fieldOfView;
        originalDist = distanceFromTarget;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, (playerTarget.position+offsetOrbitPoint) - transform.forward * distanceFromTarget, cameraSpeed);
        yaw += Input.GetAxis("Mouse X") * sensitivity.x;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity.y;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);
        
        currentRotation = Vector3.Lerp(currentRotation, new Vector3(pitch, yaw), rotationSpeed * Time.deltaTime);
        
        //TODOD : TOOO MUCH VELOCITY
        
        transform.eulerAngles = currentRotation;
        transform.position = Vector3.Lerp(transform.position, (playerTarget.position + offsetOrbitPoint) - transform.forward * distanceFromTarget, cameraSpeed);

    }

    public void ApplyingVelocity(Vector3 velocity, float time)
    {

        if (velocity.magnitude > 0.1f || velocity.magnitude < -0.1f)
        {
            if (time > 0.2f)
            {
                cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, originalFOV + fovAdd, 0.1f);
                distanceFromTarget = Mathf.Lerp(distanceFromTarget, originalDist + distanceAdd, 0.1f);
            }
           
        }
        else
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, originalFOV, 0.1f);
            distanceFromTarget = Mathf.Lerp(distanceFromTarget, originalDist, 0.1f);
        }
    }
}
