using System;
using UnityEngine;


    public class Interaction : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("interaction");
            }
        }
    }
