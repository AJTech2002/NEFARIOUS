using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour {

    [Header("Sensitivity")]
    public float accelerationSens;
    public float turnSens;
    public float punishment;
    public float reward;

    public Transform target;


    public bool DEBUG;
    public bool MARKED;


    public LayerMask rayMask;

    public float fitness;
 
    public bool dead;


    public NNet CarNetwork;

    public Matrix inputMatrix;

    public float maxDist;

    [Header("Detectors")]
    public List<Vector3> inputs = new List<Vector3>();

    public bool isTestCookie = false;



    public Vector3 startEulerAngles;
    public Vector3 startPoint;

    private void Awake()
    {
        if (isTestCookie)
        {

            startPoint = transform.position;
            startEulerAngles = transform.eulerAngles;
   
            inputMatrix.Create(1, inputs.Count);
            CarNetwork = new NNet(new Matrix(1, inputs.Count, "Yeah"));
        }
    }

    private void FixedUpdate()
    {

        Detection();
        ForwardPropogate();
    }
    public float changeIn;
    private void ForwardPropogate()
    {
    
        Matrix o = CarNetwork.ForwardPropogate(inputMatrix);
        float accel = o.v[0, 0]*accelerationSens;
        float turnL = o.v[0, 1]*turnSens;
        float turnR = o.v[0, 2]*turnSens;

        Accelerate(accel);
  
        Turn(-turnL + turnR);

    }

    float oldFitness = 0f;
    public void Detection()
    {
        float avgDistance = 0f;
        for (int i = 0; i < inputs.Count; i++)
        {
            Vector3 r = transform.TransformDirection(inputs[i]);
            r.y *= 0;
            Ray ray = new Ray(transform.position, r);
            RaycastHit hit;
            

            if (Physics.Raycast(ray, out hit, maxDist, rayMask))
            {
                if (DEBUG)
                    Debug.DrawLine(transform.position, hit.point, Color.green);

                if (inputs[i] == new Vector3(0, 0, 1) && hit.transform.CompareTag("Node"))
                {
                    //fitness += 5;
                   // print("SP ");
                }

                inputMatrix.UpdateValue(0, i, Mathf.Clamp(Mathf.Abs((hit.distance / maxDist) - 1), 0, 1));
                avgDistance += hit.distance;
            }
            else
            {
                if (DEBUG)
                    Debug.DrawLine(transform.position,transform.position+(r*100), Color.red);
                // values[i] = Mathf.Clamp(Mathf.Abs((maxDetection/maxDetection)-1),0,1);
                inputMatrix.UpdateValue(0, i, Mathf.Clamp(Mathf.Abs((hit.distance / 100) - 1), 0, 1));
            }

        }

        avgDistance /= inputs.Count;
        oldFitness = fitness;
        fitness = avgDistance;
    }

    public void Accelerate (float power)
    {
        transform.position += transform.forward * power;
    }

    public void Turn (float power)
    {

            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + power, transform.eulerAngles.z), 0.5f);

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            CarNetwork.ChangeNetwork(-punishment);
            oldFitness = 0f;
            fitness = 0f;
            transform.position = startPoint;
            transform.eulerAngles = startEulerAngles;
        }
        
        if (other.CompareTag("Node"))
        {
            CarNetwork.ChangeNetwork(reward);
            print("NODEEE");
        }

    }

}

[System.Serializable]
public class CarStore
{
    public float fitness;
    public NNet network;
}