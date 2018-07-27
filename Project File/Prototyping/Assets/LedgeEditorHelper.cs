using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LedgeSystem;

public class LedgeEditorHelper : MonoBehaviour {

    public List<CObject> ledgeObjects = new List<CObject>();

}

namespace LedgeSystem
{
    [System.Serializable]
    public class LedgePoint
    {
        public CObject parentLedge;
        public Ledge parentRef;

        public Vector3 point;

        public enum PointType { Normal, DismountPoint };
        public PointType type = PointType.Normal;

        public List<LedgeConnection> connections = new List<LedgeConnection>();

    }

    [System.Serializable]
    public class LedgeConnection
    {

        //Via Individual Point / Points

        //INDEX 0 of 'pointsA' connects to INDEX 0 of 'pointsB'

        public LedgePoint a;
        public LedgePoint b;

        public enum ConnectionType { Normal, DismountConnection, DropJumpConnection };
        public ConnectionType type = ConnectionType.Normal;

    }

    [System.Serializable]
    public class Ledge
    {
        public List<LedgePoint> points = new List<LedgePoint>();
        public enum LedgeType { Normal };

        public LedgeType type = LedgeType.Normal;
    }

    [System.Serializable]
    public class CObject
    {
        public Transform obj;
        public List<Ledge> ledges = new List<Ledge>();
    }

}