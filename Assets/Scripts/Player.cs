using System;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float clamp = 0.0025f;
    public Manager manager;
    public Animator Animator;
    
    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col);
        if (col.gameObject.CompareTag("Pickable"))
        {
            manager.currentState = States.Break;
        }
    }

    private void Update()
    {
        Animator.SetInteger("Emote", 0);
        Animator.SetFloat("Blend X", Input.GetAxis("Horizontal"));
        Animator.SetFloat("Blend Y", Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.up * (Mathf.Cos(Time.time) * clamp) / 100; //float effect
    }
}