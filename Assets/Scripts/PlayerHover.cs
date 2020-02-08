using UnityEngine;

public class PlayerHover : MonoBehaviour
{
    public float clamp = 0.0025f;
    Rigidbody rb;

    private void FixedUpdate()
    {
        transform.position += Vector3.up * (Mathf.Cos(Time.time) * clamp) / 100; //float effect
    }
}