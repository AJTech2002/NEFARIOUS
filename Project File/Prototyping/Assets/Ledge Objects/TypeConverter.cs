using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TypeConverter : MonoBehaviour {

    public Transform player;
   

    private void Awake()
    {
        object o = player;
        Type s = player.GetType();
        if (player.GetType() == o.GetType())
        {
            Transform t = (Transform)o;
            print(t.name);
        }
        
    }

}
