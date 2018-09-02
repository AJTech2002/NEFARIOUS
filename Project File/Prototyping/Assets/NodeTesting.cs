using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

public class NodeTesting : MonoBehaviour {

    [Node(10)]
    public float s;

    private void Awake()
    {
        //Monobehaviour type
        Type monoType = this.GetType();
        //What type of fields it wants to gain access to
        FieldInfo[] objectFields = monoType.GetFields(BindingFlags.Instance | BindingFlags.Public);

        for (int i = 0; i < objectFields.Length; i++)
        {
            NodeAttribute attr = Attribute.GetCustomAttribute(objectFields[i], typeof(NodeAttribute)) as NodeAttribute;

            if (attr != null)
            {
                Debug.Log(attr.id);
                Debug.Log(attr.ToString());
                Debug.Log((float)objectFields[i].GetValue(this));
                objectFields[i].SetValue(this, 10);
                Debug.Log((float)objectFields[i].GetValue(this));
            }

        }


    }

}
