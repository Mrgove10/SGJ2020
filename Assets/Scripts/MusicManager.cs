using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public AudioSource sonPioche1;
    public AudioSource sonPioche2;
    public AudioSource sonPioche3;

    public AudioSource sonContent1;
    public AudioSource sonContent2;

    public AudioSource sonParle1;
    public AudioSource sonParle2;
    public AudioSource sonParle3;
    public AudioSource sonParle4;
    public AudioSource sonParle5;
    public AudioSource sonParle6;
    public AudioSource sonParle7;
    public AudioSource sonParle8;

    public AudioSource sonTranchePierre;

    public AudioSource sonDeplisBras;
    public AudioSource sonReplisBras;

    public AudioSource sonCoupVent;

    private int rand;
    private int rand2;
    private int rand3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SonPiocheF()
    {
        rand3 = Random.Range(1, 4);
    
        switch (rand3)
        {
            case 1:
                sonPioche1.Play();
                break;
            case 2:
                sonPioche2.Play();
                break;
            case 3:
                sonPioche3.Play();
                break;
            default:
                break;
        }
    }

    public void SonTranchePierreF()
    {
        sonTranchePierre.Play();
    }

    public void SonDeplisBrasF()
    {
        sonDeplisBras.Play();
    }

    public void SonReplisBrasF()
    {
        sonReplisBras.Play();
    }

    public void SonCoupVentF()
    {
        sonCoupVent.Play();
    }

    public void SonContentF()
    {
        rand = Random.Range(0, 2);
        if(rand == 1)
        {
            sonContent1.Play();
        }
        else
        {
            sonContent2.Play();
        }
    }

    public void SonParleF()
    {
        rand2 = Random.Range(1, 9);

        switch (rand2)
        {
            case 1:
                sonParle1.Play();
                break;
            case 2:
                sonParle2.Play();
                break;
            case 3:
                sonParle3.Play();
                break;
            case 4:
                sonParle4.Play();
                break;
            case 5:
                sonParle5.Play();
                break;
            case 6:
                sonParle6.Play();
                break;
            case 7:
                sonParle7.Play();
                break;
            case 8:
                sonParle8.Play();
                break;
            default:
                break;
        }
    }
}
