using UnityEngine;
[ExecuteInEditMode]
public class DrawLine : MonoBehaviour
{
    // an array of game objects which will have a
    // line drawn to in the scene editor
    public GameObject[] GameObjects;

    private void OnDrawGizmos()
    {

        //MeshFilter go = GameObject.FindObjectOfType<DrawLine>().GetComponent<MeshFilter>();
       // Vector3[] v = go.sharedMesh.vertices;
        //for (int i = 0; i < v.Length; i++)
       // {

        //    Gizmos.DrawWireSphere(go.transform.TransformPoint(v[i]), 0.05f);
        //}
    }

}