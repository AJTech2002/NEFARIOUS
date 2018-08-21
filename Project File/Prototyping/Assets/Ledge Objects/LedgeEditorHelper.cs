using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LedgeSystem;
using UnityEditor;

public class LedgeEditorHelper : MonoBehaviour {

    public List<CObject> ledgeObjects = new List<CObject>();

}

namespace LedgeSystem
{
    [System.Serializable]
    public class LedgePoint
    {
        public CObject parentLedge;

        public List<LedgeConnection> connections = new List<LedgeConnection>();

        public Vector3 RelativePoint;
        public Vector3 AbsolutePoint
        {
           /* get
            {
                return parentLedge.transform.InverseTransformPoint(RelativePoint);
            } */

            get
            {
                if (parentLedge != null)
                return parentLedge.transform.TransformPoint(parentLedge.m.vertices[index]);

                return Vector3.zero;

            }
            
        }

        public int parentLedgeIndex = 0;
        public int thisIndex = 0;
        public int index;

        public enum PointType { Normal, DismountPoint, FallPoint, SinglePoint, HangingPoint };
        public PointType type = PointType.Normal;

        //public List<LedgeConnection> connections = new List<LedgeConnection>();

        public LedgePoint (CObject _parent, int vertIndex, PointType _type, int pLedgeIndex, int thisIndex)
        {
            parentLedge = _parent;
            index = vertIndex;
            parentLedgeIndex = pLedgeIndex;
            this.thisIndex = thisIndex;
            type = _type;
        }

        public bool IsEqualTo (Vector3 relativePoint)
        {
            if (relativePoint == RelativePoint)
                return true;

            return false;
        }

    }

    [System.Serializable]
    public class LedgePair
    {
        [HideInInspector]
        public LedgePoint a;
        [HideInInspector]
        public LedgePoint b;

        public bool FillUp(LedgePoint fill)
        {
            if (a == null && b == null)
            {
                a = fill;
                return true;
            }

            if (b == null)
            {
                if (fill.parentLedge == a.parentLedge && fill.parentLedgeIndex == a.parentLedgeIndex)
                {
                    b = fill;
                    return true;
                }
            }

            return false;
        }

        public LedgePair (LedgePoint _a, LedgePoint _b)
        {
            a = _a;
            b = _b;
        }

        public LedgePair()
        {

        }
       

    }

    [System.Serializable]
    public class LedgeConnection
    {

        //Via Individual Point / Points

        //INDEX 0 of 'pointsA' connects to INDEX 0 of 'pointsB'


        public LedgePair a;
        public LedgePair b;

        public enum ConnectionType { Normal, DismountConnection, DropJumpConnection };
        public ConnectionType type = ConnectionType.Normal;

        public LedgeConnection (ConnectionType t, LedgePair a, LedgePair b)
        {
            type = t;
            this.a = a;
            this.b = b;
        }

        public bool Contains (LedgePoint a, LedgePoint b)
        {
            if (this.a.a == a || this.a.b == a || this.b.b == a || this.b.a == a)
            {
                if (this.a.a == b || this.a.b == b || this.b.b == b || this.b.a == b)
                {
                    return true;
                }
            }

            return false;

        }

        public LedgePair whichPair (LedgePoint a, LedgePoint b)
        {
            if (this.a.a == a || this.a.b == a)
            {
                if (this.a.b == b || this.a.a == a)
                {
                    return this.a;
                }
            }

            if (this.b.a == a || this.b.b == a)
            {
                if (this.b.b == b || this.b.a == b)
                {
                    return this.b;
                }
            }

            return null;

        }

        public LedgePair whichOppositePair(LedgePoint a, LedgePoint b)
        {
            if (this.a.a.parentLedgeIndex == a.parentLedgeIndex && this.a.a.parentLedge == a.parentLedge|| this.a.b.parentLedgeIndex == a.parentLedgeIndex && this.a.b.parentLedge == a.parentLedge)
            {
                if (this.a.a.parentLedgeIndex == b.parentLedgeIndex && this.a.a.parentLedge == b.parentLedge || this.a.b.parentLedgeIndex == b.parentLedgeIndex && this.a.b.parentLedge == b.parentLedge)
                {
                    return this.b;
                }
            }

            if (this.b.a.parentLedgeIndex == a.parentLedgeIndex && this.b.a.parentLedge == a.parentLedge || this.b.b.parentLedgeIndex == a.parentLedgeIndex && this.b.b.parentLedge == a.parentLedge)
            {
                if (this.b.a.parentLedgeIndex == b.parentLedgeIndex && this.b.a.parentLedge == b.parentLedge || this.b.b.parentLedgeIndex == b.parentLedgeIndex && this.b.b.parentLedge == b.parentLedge)
                {
                    return this.a;
                }
            }

            return null;

        }

        public void DrawConnection()
        {
            if (a != null && a.a != null && a.b != null && b != null && b.a != null && b.b != null)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawLine(a.a.AbsolutePoint, a.b.AbsolutePoint);
                Gizmos.color = Color.magenta;
                Gizmos.DrawLine(a.a.AbsolutePoint, b.a.AbsolutePoint);
                Gizmos.DrawLine(a.b.AbsolutePoint, b.a.AbsolutePoint);
                Gizmos.DrawLine(a.b.AbsolutePoint, b.b.AbsolutePoint);
                Gizmos.DrawLine(a.a.AbsolutePoint, b.b.AbsolutePoint);
                Gizmos.color = Color.black;
                Gizmos.DrawLine(b.a.AbsolutePoint, b.b.AbsolutePoint);
            }
        }

    }

    [System.Serializable]
    public class Ledge
    {
        public List<LedgePoint> points = new List<LedgePoint>();
        public enum LedgeType { Normal };
        public bool isLoopedConnection;

        public LedgeType type = LedgeType.Normal;

        public Ledge (LedgeType _type, List<LedgePoint> _points, bool loopedConnection)
        {
            for (int i = 0; i < _points.Count; i++)
            {
                LedgePoint p = _points[i];

                points.Add(p);
            }

            isLoopedConnection = loopedConnection;
            

            type = _type;

        }

    }

    public class Face { 
            
        public Face (Vector3 p0_, Vector3 p1_, Vector3 p2_, Transform t, int iP0, int iP1, int iP2, Mesh m)
        {
            p0 = p0_;
            p1 = p1_;
            p2 = p2_;
            trans = t;

            p0index = iP0;
            p1index = iP1;
            p2index = iP2;

            tempMesh = m;
        }

        public Mesh tempMesh;

        public int p0index, p1index, p2index;

        public Transform trans;

        public Vector3 p0, p1, p2;

        public Vector3 RP0
        {
            get
            {
                return HandleUtility.WorldToGUIPoint(p0);
            }
        }

        public Vector3 RP1
        {
            get
            {
                return HandleUtility.WorldToGUIPoint(p1);
            }
        }
        public Vector3 RP2
        {
            get
            {
                return HandleUtility.WorldToGUIPoint(p2);
            }
        }


    }


    public class LedgeConnectRef
    {
        public Transform mainTransform;
        public Mesh attachedMesh;
        public int vertexIndex;

        public LedgeConnectRef (Transform t, Mesh m, int i)
        {
            mainTransform = t;
            attachedMesh = m;
            vertexIndex = i;
        }

    }

}

public static class EdgeHelpers
{
    public struct Edge
    {
        public int v1;
        public int v2;
        public int triangleIndex;
        public Edge(int aV1, int aV2, int aIndex)
        {
            v1 = aV1;
            v2 = aV2;
            triangleIndex = aIndex;
        }
    }

    public static List<Edge> GetEdges(int[] aIndices)
    {
        List<Edge> result = new List<Edge>();
        for (int i = 0; i < aIndices.Length; i += 3)
        {
            int v1 = aIndices[i];
            int v2 = aIndices[i + 1];
            int v3 = aIndices[i + 2];
            result.Add(new Edge(v1, v2, i));
            result.Add(new Edge(v2, v3, i));
            result.Add(new Edge(v3, v1, i));
        }
        return result;
    }

    public static List<Edge> FindBoundary(this List<Edge> aEdges)
    {
        List<Edge> result = new List<Edge>(aEdges);
        for (int i = result.Count - 1; i > 0; i--)
        {
            for (int n = i - 1; n >= 0; n--)
            {
                if (result[i].v1 == result[n].v2 && result[i].v2 == result[n].v1)
                {
                    // shared edge so remove both
                    result.RemoveAt(i);
                    result.RemoveAt(n);
                    i--;
                    break;
                }
            }
        }
        return result;
    }
    public static List<Edge> SortEdges(this List<Edge> aEdges)
    {
        List<Edge> result = new List<Edge>(aEdges);
        for (int i = 0; i < result.Count - 2; i++)
        {
            Edge E = result[i];
            for (int n = i + 1; n < result.Count; n++)
            {
                Edge a = result[n];
                if (E.v2 == a.v1)
                {
                    // in this case they are already in order so just continoue with the next one
                    if (n == i + 1)
                        break;
                    // if we found a match, swap them with the next one after "i"
                    result[n] = result[i + 1];
                    result[i + 1] = a;
                    break;
                }
            }
        }
        return result;
    }

}


