using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AJTech;
using AJTech.AI;

namespace AJTech.Management
{
    public class BehaviourProfile : MonoBehaviour
    {

        public Transform t;
        public Vector3 position
        {
            get
            {
                return this.t.position;
            }
        }

        private void Awake()
        {
            t = transform;
        }

        public List<Vector3> accessPoints = new List<Vector3>();

        private void OnDrawGizmosSelected()
        {
            foreach (Vector3 v in accessPoints)
            {
                Gizmos.color = Color.magenta;
                Gizmos.DrawWireSphere(transform.TransformPoint(v), 0.13f);
            }
        }



    }



}

namespace AJTech {
    public interface ITriggerRegistered
    {
        void TriggerRegistered();
    }
}