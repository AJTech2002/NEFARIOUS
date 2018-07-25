using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AJTech;

namespace AJTech.AI
{
    public class ViewNode : MonoBehaviour
    {




    }
}

namespace AJTech
{
    public class RayCaster
    {
        public bool RayCast (Vector3 origin, Vector3 dir, float maxDist, LayerMask mask, out RaycastHit hitObj)
        {
            Ray ray = new Ray(origin, dir);

            RaycastHit hit;

            if (Physics.Raycast(ray , out hit, maxDist, mask))
            {
                hitObj = hit;
                return true;
            }


            hitObj = hit;
            return false;

        }

        public bool RayCast(Vector3 origin, Vector3 dir, out RaycastHit hitObj)
        {
            Ray ray = new Ray(origin, dir);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                hitObj = hit;
                return true;
            }


            hitObj = hit;
            return false;

        }

    }
}