using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticManager : MonoBehaviour {
    public GameObject prefab;
    public float maxPopulationTime;
    public int breedCount = 20;
    public float topSelectionPercentage;
    public int minimumTopSelection = 5;
    public int extras;
    public GraphHelp help;
    public float mutationChance = 0.2f;

    Vector3 startPos;
    Vector3 startRot;

    public List<CarStore> cars = new List<CarStore>();
    public List<CarManager> carManagers = new List<CarManager>();

    private void Awake()
    {
        startPos = GameObject.FindObjectOfType<CarManager>().transform.position;
        startRot = GameObject.FindObjectOfType<CarManager>().transform.eulerAngles;

        foreach (CarManager m in GameObject.FindObjectsOfType<CarManager>() )
        {
            carManagers.Add(m);
        }

    }

    private void Update()
    {
        int deathCount = 0;
        for (int i = 0; i < carManagers.Count; i++)
        {
            if (carManagers[i].dead)
                deathCount++;

        }

        if (deathCount >= carManagers.Count)
        {
            cars.Clear();
            for (int i = 0; i < carManagers.Count; i++)
            {
                CarStore s = new CarStore();
                s.fitness = carManagers[i].fitness;
                s.network = carManagers[i].CarNetwork;
                cars.Add(s);
            }

            ListBestFitness();
            

        }

    }

    private void ListBestFitness()
    {
        List<CarStore> stores = cars;
        stores = BubbleSort(stores);
        stores.Reverse();
        print("Stores :" + stores[0].fitness + " END F" + stores[stores.Count - 1].fitness);
        GenePool(stores);
    }

    private void GenePool(List<CarStore> storePick)
    {
        List<CarStore> spawnStore = new List<CarStore>();

        int top = Mathf.RoundToInt(cars.Count * topSelectionPercentage);

        for (int i = 0; i < top; i++)
        {
            spawnStore.Add(storePick[i]);
        }


        for (int i = 0; i < breedCount; i++)
        {
            CarStore a = spawnStore[Random.Range(0, spawnStore.Count)];
            CarStore b = spawnStore[Random.Range(0, spawnStore.Count)];
         
            CarStore c = new CarStore();
            c.network = a.network;

            float mutation = Random.Range(0f, 1f);
            if (mutation < mutationChance)
            {
                c.network = new NNet(new Matrix(1, 5, "Yeah"));
            }
            else {

                int type = Random.Range(0, 3);

                if (type == 0)
                {
                    c.network.h1Weights = a.network.h1Weights;
                    c.network.h2Weights = b.network.h2Weights;
                    c.network.outPWeights = a.network.outPWeights.HalfCombine(b.network.outPWeights);
                }
                else if (type == 1)
                {
                    c.network.h1Weights = b.network.h1Weights.HalfCombine(a.network.h1Weights);
                    c.network.h2Weights = a.network.h2Weights.HalfCombine(b.network.h2Weights);
                    c.network.outPWeights = b.network.outPWeights.HalfCombine(a.network.outPWeights);
                }
                else if (type == 2)
                {
                    c.network.h1Weights = b.network.h1Weights.AverageCombine(a.network.h1Weights);
                    c.network.h2Weights = a.network.h2Weights.AverageCombine(b.network.h2Weights);
                    c.network.outPWeights = b.network.outPWeights.AverageCombine(a.network.outPWeights);
                }

            }

            spawnStore.Add(c);

        }


        for (int e = 0; e < extras; e++)
        {
            int i = Random.Range(0, cars.Count);
            spawnStore.Add(storePick[i]);
        }


        for (int i = 0; i < carManagers.Count; i++)
        {
            Destroy(carManagers[i].gameObject, 0f);
        }

        carManagers.Clear();

        for (int i = 0; i < spawnStore.Count; i++)
        {
            GameObject go = (GameObject)Instantiate(prefab);
            go.GetComponent<CarManager>().NewCar(startPos, startRot, 0, 0, spawnStore[i].network);
            carManagers.Add(go.GetComponent<CarManager>());
        }

    }

    List<CarStore> BubbleSort(List<CarStore> array)
    {
        List<CarStore> arr = array;
        CarStore temp;

        for (int write = 0; write < arr.Count; write++)
        {
            for (int sort = 0; sort < arr.Count - 1; sort++)
            {
                if (arr[sort].fitness > arr[sort + 1].fitness)
                {
                    temp = arr[sort + 1];
                    arr[sort + 1] = arr[sort];
                    arr[sort] = temp;
                }
            }
        }

        return array;

    }

}
