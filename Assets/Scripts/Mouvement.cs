using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{

    CharacterController characterController;

    public float speed = 6.0f;

    private Vector3 moveDirection = Vector3.zero;
    
    void Start()
        {
            characterController = GetComponent<CharacterController>();
        }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;
            characterController.Move(moveDirection * Time.deltaTime);
        }

        /*if (Input.GetAxis("Vertical") > 1) //Front
        {
            player.Move(new)
        }

        if (Input.GetAxis("Vertical") < 1) //Back
        {
        }

        if (Input.GetAxis("Horizontal") > 1) //Right
        {
        }

        if (Input.GetAxis("Horizontal") < 1) //Left
        {
        }*/
    }
}