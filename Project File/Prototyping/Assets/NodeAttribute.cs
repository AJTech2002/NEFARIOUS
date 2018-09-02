using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEditor;
using System;



[System.AttributeUsage(AttributeTargets.Field)]
public class NodeAttribute : Attribute {

    public readonly int id;

    public NodeAttribute(int id)
    {
        this.id = id;
    }


}
