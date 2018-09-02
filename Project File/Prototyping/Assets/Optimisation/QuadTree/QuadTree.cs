using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Optimisation
{
    public class QuadTree<T>
    {
        //Amount of objects allowed inside this region before subdivision...
        const int QT_NODE_CAPACITY = 4;

        public int Length
        {
            get
            {
                return points.Length;
            }
        }

        AABB boundary;

        //Did you know constants can be referenced without harm
        QuadObject<T>[] points = new QuadObject<T>[QT_NODE_CAPACITY];

        //Children Quadtrees
        QuadTree<T> northWest;
        QuadTree<T> northEast;
        QuadTree<T> southWest;
        QuadTree<T> southEast;

        public QuadTree(AABB _bounds)
        {
            boundary = _bounds;
        }


        public bool Insert (QuadObject<T> item)
        {
            if (!boundary.containsPoint(new Vector2(item.position.x, item.position.z)))
                return false;

            if (points.Length < QT_NODE_CAPACITY)
            {
                points[points.Length - 1] = item;
                return true;
            }

            //North West is top left (First position)... If the capacity is higher and point is in bounds, we have to subdivide...
            if (northWest == null)
                Subdivide();

            
            //Try and send the point to one of the subdivisions and if accepted, return true
            if (northWest.Insert(item)) return true;
            if (northEast.Insert(item)) return true;
            if (southEast.Insert(item)) return true;
            if (southWest.Insert(item)) return true;

            //For some reason the point cannot be inserted
            Debug.LogError("There is an error, point is in range but subdivision has failed...");

            return false;

        }

        private void Subdivide()
        {
            Rect r = boundary.quad;

            Rect nw = new Rect(r.center, r.size / 2);
            nw.center = new Vector2(r.center.x - r.size.x / 4, r.center.y + r.size.y / 4);

            Rect ne = new Rect(r.center, r.size / 2);
            ne.center = new Vector2(r.center.x + r.size.x / 4, r.center.y + r.size.y / 4);

            Rect sw = new Rect(r.center, r.size / 2);
            sw.center = new Vector2(r.center.x - r.size.x / 4, (r.center.y - r.size.y / 4));

            Rect se = new Rect(r.center, r.size / 2);
            se.center = new Vector2(r.center.x + r.size.x / 4, (r.center.y - r.size.y / 4));

            northWest = new QuadTree<T>(new AABB(nw));
            northEast = new QuadTree<T>(new AABB(ne));
            southEast = new QuadTree<T>(new AABB(se));
            southWest = new QuadTree<T>(new AABB(sw));
            //bounding . quad . center (find out how rects work)
        }

        public void QueryRange (Rect B_boundary)
        {
            List<QuadObject<T>> items = new List<QuadObject<T>>();

            // Check if boundary.intersects(B_boundary) if it doesnt, return null

            for (int p = 0; p < items.Count; p++)
            {
               //Check if our points contains item

            }

            //if NOT subdivided then return

            //Repeat below for 4 subdivisions
            // items.Add(northWest.queryRange(range));
           
        }

    }

    public class QuadObject <T>
    {
        public Vector3 position;
        public T obj;

        public QuadObject (Vector3 _pos, T _obj)
        {
            position = _pos;
            obj = _obj;
        }

        public QuadObject()
        {

        }

    }
    
    //Regional Bounding Box
    public class AABB
    {
        public Rect quad;

        public AABB (Rect _quad)
        {
            quad = _quad;
        }

        public bool containsPoint (Vector2 point)
        {
            if (quad.Contains(point))
                return true;

            return false;
        }


        public float width ()
        {
            return quad.width;
        }

        public float height()
        {
            return quad.height;
        }

        public float xPOS()
        {
            return quad.position.x;
        }

        public float yPOS()
        {
            return quad.position.y;
        }

    }

}
