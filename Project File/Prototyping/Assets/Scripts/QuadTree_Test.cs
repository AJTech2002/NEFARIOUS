using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Optimisation;

public class QuadTree_Test : MonoBehaviour {

    public Rect r;

    public QuadTree<Transform> transforms;


    private void Awake()
    {
        transforms = new QuadTree<Transform>(new AABB(r));
    }


    private void OnDrawGizmos()
    {
    }

}

#region end

/*
Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(new Vector3(r.center.x,0, r.center.y), new Vector3(r.size.x,0, r.size.y));

        Rect nw = new Rect(r.center, r.size / 2);
nw.center = new Vector2(r.center.x - r.size.x / 4, r.center.y + r.size.y /4);
Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector3(nw.center.x,0, nw.center.y), new Vector3(nw.size.x, 0, nw.size.y));

        Rect ne = new Rect(r.center, r.size / 2);
ne.center = new Vector2(r.center.x + r.size.x / 4, r.center.y + r.size.y / 4);
Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(new Vector3(ne.center.x, 0, ne.center.y), new Vector3(ne.size.x, 0, ne.size.y));

        Rect sw = new Rect(r.center, r.size / 2);
sw.center = new Vector2(r.center.x - r.size.x / 4, (r.center.y - r.size.y/4));
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(new Vector3(sw.center.x, 0, sw.center.y), new Vector3(sw.size.x, 0, sw.size.y));

        Rect se = new Rect(r.center, r.size / 2);
se.center = new Vector2(r.center.x + r.size.x / 4, (r.center.y - r.size.y/4));
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(new Vector3(se.center.x, 0, se.center.y), new Vector3(se.size.x, 0, se.size.y));

    */
#endregion
