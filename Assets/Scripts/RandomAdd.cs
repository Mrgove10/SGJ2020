
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
    

    }
}