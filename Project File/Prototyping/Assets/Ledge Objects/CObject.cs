using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LedgeSystem;

[System.Serializable]
public class CObject : MonoBehaviour {

    
    public bool drawGizmos;
    public bool drawAll;
    public bool useTransformForward;

    [Header("Attributes")]
    public int segmentDivison = 10;

    [Header("Properties")]
    public Transform obj;
    public List<Ledge> ledges = new List<Ledge>();

    

    [HideInInspector]
    public Mesh m;


    private void Awake()
    {
        if (m == null) { 
            m = GetComponent<MeshCollider>().sharedMesh;

        }
    }

    /* DISPLAY IN GIZMOS */
    private void OnDrawGizmos()
    {
        if (drawGizmos)
        {
            if (m != null)
            {
                for (int i = 0; i < ledges.Count; i++)
                {
                    for (int p = 0; p < ledges[i].points.Count; p++)
                    {
                        Gizmos.color = Color.magenta;
                        Gizmos.DrawCube(ledges[i].points[p].AbsolutePoint, Vector3.one / 5);

                        if (p == 0)
                            continue;


                        Gizmos.DrawLine(ledges[i].points[p - 1].AbsolutePoint, ledges[i].points[p].AbsolutePoint);

                        if (ledges[i].isLoopedConnection)
                            Gizmos.DrawLine(ledges[i].points[ledges[i].points.Count - 1].AbsolutePoint, ledges[i].points[0].AbsolutePoint);

                    }

                    //TFD


                }



            }

           

        }
    }

    private void OnDrawGizmosSelected()
    {
        if (drawGizmos)
        {
            for (int i = 0; i < ledges.Count; i++)
            {
                for (int p = 0; p < ledges[i].points.Count; p++)
                {

                    for (int c = 0; c < ledges[i].points[p].connections.Count; c++)
                    {
                        ledges[i].points[p].connections[c].DrawConnection();
                        if (!drawAll)
                            break;
                    }

                }

            }
        }
    }


    public List<LedgePoint> retAllPoints ()
    {
        List<LedgePoint> pts = new List<LedgePoint>();

        for (int i = 0; i < ledges.Count; i++)
        {
            for (int p = 0; p < ledges[i].points.Count; p++)
            {
                pts.Add(ledges[i].points[p]);


            }
        }

        return pts;

    }

    public List<LedgeInformation> returnPointsFrom (int i)
    {
        List<LedgeInformation> pts = new List<LedgeInformation>();

        for (int p = 0; p < ledges[i].points.Count; p++)
        {
            LedgeInformation r = new LedgeInformation(ledges[i].points[p], i, 0);
            Debug.LogError("This code is broken");
;            pts.Add(r);
            
        }

        return pts;
    }


    public List<LedgePoint> returnRealPointsFrom(int i)
    {
        List<LedgePoint> pts = new List<LedgePoint>();

        for (int p = 0; p < ledges[i].points.Count; p++)
        {
            pts.Add(ledges[i].points[p]);

        }

        return pts;
    }

    public List<Vector3> selectionDivision (LedgePoint a, LedgePoint b) 
    {
        List<Vector3> l = new List<Vector3>();
        Vector3 spacer = (b.AbsolutePoint - a.AbsolutePoint) / segmentDivison;

        for (int i = 0; i < segmentDivison; i++)
        {
            Vector3 p = a.AbsolutePoint + (spacer * i);
            l.Add(p);
        }

        return l;

    }

}


