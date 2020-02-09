using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rock : MonoBehaviour
{

    public bool timeAdder = false;
    public EColor color;
    public AudioSource rockMusic;
    public AdaptiveMusicScript musicSource;
    public GameObject image;
    public void Start()
    {
        switch (color)
        {    
            case EColor.rouge:
                rockMusic.clip = musicSource.melodiaMusicV1;
                break;
            case EColor.bleu:
                rockMusic.clip = musicSource.melodiaMusicV2;
                break;
            case EColor.vert:
                rockMusic.clip = musicSource.melodiaMusicV3;
                break;
            case EColor.orange:
                rockMusic.clip = musicSource.melodiaMusicV4;
                break;
            default:
                break;
        }

        rockMusic.Play();
    }

    private void Update()
    {
        image.transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward);
    }
}

public enum EColor
{
    rouge,
    bleu,
    vert,
    orange
}
