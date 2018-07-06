using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OdinSerializer;
using AOT;


public class NetworkTesting : SerializedMonoBehaviour {

    [Header("References")]
    public GraphHelp helper;

    public float e=1f;
    public float multiplier;


    private void Awake()
    {
        helper.AddGraph("Test", Color.red);
    }
    private void Update()
    {
        e += e * multiplier;
        helper.Plot(Time.time, e, 0);

        helper.DeletePointsAtThreshold(1000, "Test");

    }



}
