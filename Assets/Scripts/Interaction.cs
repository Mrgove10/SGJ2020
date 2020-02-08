using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Manager manager;
    public GameObject rock;
    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("interaction");
            manager.currentState = States.Break;
        }

        if (manager.currentState == States.Break)
        {
            TurnObject();
        }
    }

    void TurnObject()
    {
        float rotationSpeed = 15;

        float xAxis = Input.GetAxis("Mouse X") * rotationSpeed;
        float yAxis = Input.GetAxis("Mouse Y") * rotationSpeed;

        rock.transform.Rotate(Vector3.up, -xAxis, Space.World);
        rock.transform.Rotate(Vector3.right, yAxis, Space.World);
    }
}