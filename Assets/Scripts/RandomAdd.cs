
//using System.Drawing.Drawing2D;
using UnityEngine;
//using Maths;

public class RandomAdd : MonoBehaviour
{
    public GameObject earth;
    public GameObject spawn;
     Mesh mesh;
    Vector3[] vertices;

    void Start()
    {
        mesh = earth.GetComponent<MeshFilter>().mesh;
    
         //Matrix 4x4 localToWorld = transform.localToWorldMatrix;
         
         /*for(int i = 0; i<mf.mesh.vertices.Length; ++i){
               Vector3 world_v = localToWorld.MultiplyPoint3x4(mf.mesh.vertices[i]);
         }*/
    }
}