using System;
using UnityEngine;

public class Animation : MonoBehaviour
    {
        public Animator Animator;

        private void Update()
        {
            Animator.SetInteger("Emote",0);
            Animator.SetFloat("Blend X",Input.GetAxis("Horizontal"));
            Animator.SetFloat("Blend Y", Input.GetAxis("Vertical"));
        }
    }
    