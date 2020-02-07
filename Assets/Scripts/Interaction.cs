using System;
using UnityEngine;


    public class Interaction : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("interaction");
            }
        }
    }
