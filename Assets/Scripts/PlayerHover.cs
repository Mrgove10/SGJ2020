
using UnityEngine;


public class PlayerHover : MonoBehaviour
{
 public float clamp = 0.0025f;
    private void Update()
    {
        transform.position += Vector3.up * (Mathf.Cos(Time.time) * clamp);
    }
}