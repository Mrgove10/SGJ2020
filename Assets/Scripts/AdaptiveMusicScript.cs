using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptiveMusicScript : MonoBehaviour
{
    public AudioSource melodiaBase;
    public AudioSource melodiaV1;
    public AudioSource melodiaV2;
    public AudioSource melodiaV3;
    public AudioSource melodiaV4;

    public bool melodiaPlayV1;
    public bool melodiaPlayV2;
    public bool melodiaPlayV3;
    public bool melodiaPlayV4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (melodiaPlayV1)
        {
            melodiaV1.volume = 0.5f;
        }
        else
        {
            melodiaV1.volume = 0;
        }

        if (melodiaPlayV2)
        {
            melodiaV2.volume = 0.5f;
        }
        else
        {
            melodiaV2.volume = 0;
        }

        if (melodiaPlayV3)
        {
            melodiaV3.volume = 0.5f;
        }
        else
        {
            melodiaV3.volume = 0;
        }

        if (melodiaPlayV4)
        {
            melodiaV4.volume = 0.5f;
        }
        else
        {
            melodiaV4.volume = 0;
        }
    }
    public void ResetMusicAdapt()
    {
        melodiaPlayV1 = false;
        melodiaPlayV2 = false;
        melodiaPlayV3 = false;
        melodiaPlayV4 = false;
    }
}
