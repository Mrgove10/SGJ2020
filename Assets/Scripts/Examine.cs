using System.ComponentModel;
using UnityEngine;

public class Examine : MonoBehaviour
{
    Camera mainCam; //Camera Object Will Be Placed In Front Of
    GameObject clickedObject; //Currently Clicked Object

    //Holds Original Postion And Rotation So The Object Can Be Replaced Correctly
    Vector3 originaPosition;
    Vector3 originalRotation;

    //If True Allow Rotation Of Object
    // [ReadOnly]
    public bool examineMode;


    void Start()
    {
        mainCam = Camera.main;
        examineMode = false;
    }

    private void Update()
    {
        TurnObject(); //Allows Object To Be Rotated
    }

    void TurnObject()
    {
        if (examineMode)
        {
            float rotationSpeed = 15;

            float xAxis = Input.GetAxis("Mouse X") * rotationSpeed;
            float yAxis = Input.GetAxis("Mouse Y") * rotationSpeed;

            clickedObject.transform.Rotate(Vector3.up, -xAxis, Space.World);
            clickedObject.transform.Rotate(Vector3.right, yAxis, Space.World);
        }
    }
}