using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour {

    public Transform target;
    public GeneticManager manage;

    public bool DEBUG;
    public bool MARKED;


    public LayerMask rayMask;

    public float fitness;
    public bool dead;


    public NNet CarNetwork;

    public Matrix inputMatrix;

    [Header("Detectors")]
    public List<Vector3> inputs = new List<Vector3>();

    public bool isTestCookie = false;


    public void NewCar (Vector3 startPos, Vector3 startRot, float _speed, float _maxDetection, NNet network)
    {
       
        startPoint = startPos;
        transform.position = startPos;
        startEulerAngles = startRot;
        transform.eulerAngles = startRot;
        inputMatrix.Create(1, 5);
        CarNetwork = network;
    }

    private void Awake()
    {
        if (isTestCookie)
        {

            startPoint = transform.position;
            startEulerAngles = transform.eulerAngles;
   
            inputMatrix.Create(1, 5);
            CarNetwork = new NNet(new Matrix(1, 5, "Yeah"));
        }
    }
    public CarStore myStore;
    public Vector3 startEulerAngles;
    public Vector3 startPoint;
    private float maxDist;
    float deltaTime = 0;
    private void FixedUpdate()
    {
        if (!dead)
        {
           

            deltaTime += Time.deltaTime;
            // fitness += (deltaTime * 0.4f);
            iterations += 1;
            Detection();
            ForwardPropogate();

        }
        else
        {
            
            this.GetComponent<MeshRenderer>().enabled = false;
            DEBUG = false;
           // Destroy(this.gameObject, 2);
        }
        
    }

    public void ReStore (CarStore a)
    {
        CarNetwork = a.network;
        dead = false;
    }

    public void ForwardPropogate()
    {
     //   print(inputMatrix.v[0, 4]);
        Matrix output = CarNetwork.ForwardPropogate(inputMatrix);
        float leftProbability = output.v[0, 0];
        float rightProbability = output.v[0, 1];
        float forwardProb = output.v[0, 2];
        detection = output.v[0, 3]*10;
        
        if (leftProbability > rightProbability)
            Turn(-leftProbability*5);
        else
            Turn(rightProbability*5);

       Accelerate(forwardProb*0.6f);

        if (forwardProb <= 0.07f)
            dead = true;


       // Turn(steering);

    }

    float avgDistance = 0f;
    int flagMultiplier = 1;
    int iterations = 0;
    float detection = 10f;
    public void Detection()
    {
        avgDistance = 0f;
        for (int i = 0; i < inputs.Count; i++)
        {
            Vector3 r = transform.TransformDirection(inputs[i]);
            r.y *= 0;
            Ray ray = new Ray(transform.position, r);
            RaycastHit hit;
            

            if (Physics.Raycast(ray, out hit, detection, rayMask))
            {
                if (DEBUG)
                    Debug.DrawLine(transform.position, hit.point, Color.green);

                if (inputs[i] == new Vector3(0, 0, 1) && hit.transform.CompareTag("Node"))
                {
                    fitness += 5;
                   // print("SP ");
                }

                inputMatrix.UpdateValue(0, i, Mathf.Clamp(Mathf.Abs((hit.distance / 100) - 1), 0, 1));
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

        fitness += ((avgDistance*flagMultiplier))/iterations;

    }

    public void Accelerate (float power)
    {
        transform.position += transform.forward * power;
    }

    public void Turn (float power)
    {

            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + power, transform.eulerAngles.z), 0.5f);

    }

    public void Dead()
    {
        dead = true;
        deltaTime = 0f;
        fitness -= 4;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Dead();
        }
        
        if (other.CompareTag("Node"))
        {
            fitness += 50;
            flagMultiplier += 2;
        }

    }

}

[System.Serializable]
public class CarStore
{
    public float fitness;
    public NNet network;
}