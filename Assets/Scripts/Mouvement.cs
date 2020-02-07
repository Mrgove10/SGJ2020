using UnityEngine;

public class Mouvement : MonoBehaviour
{
    public float speed = 6.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 0.0f, -Input.GetAxis("Horizontal") * speed * Time.deltaTime, Space.World);
        transform.Rotate(-Input.GetAxis("Vertical") * speed * Time.deltaTime, 0.0f, 0.0f, Space.World);
    }
}