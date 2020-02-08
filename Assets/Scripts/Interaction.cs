using System;
using UnityEngine;


public class Interaction : MonoBehaviour
{
    public Manager manager;
    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("interaction");
            manager.currentState = States.Break;
        }
    }
}