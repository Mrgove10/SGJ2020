using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NaughtyAttributes;

public class Slice : MonoBehaviour
{
    public Slider mainSlider; //Le Slider dont la valeur change tout le temps
    public Slider sliderBorneHaut; //La borne haut
    public Slider SliderBorneBas; //La borne bas
    public TMP_Text resulText; //Text pour le test permetant de savoir si l'utilisateur se trompe ou non
    public float pas; //Le pas (la vitesse à laquelle le slider bouge)
    public AdaptiveMusicScript adaptiveMusic;

    [Required]
    public Manager manager;
    private bool signePas; //Le signe du pas (négatif ou positif)
    public bool stopSlide; //Variable qui permet de stopper ou non le slider (true le stoppe)

    public GameObject ROckTop;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        signePas = true;
        stopSlide = false;
        pas = 1.6f;

        sliderBorneHaut.value = Random.Range(25, 80);
        SliderBorneBas.value = sliderBorneHaut.value - Random.Range(10, 25);
        resulText.text = "";
    }

    public void randomizer()
    {
        signePas = true;
        stopSlide = false;
        pas = 1.6f;

        sliderBorneHaut.value = Random.Range(25, 80);
        SliderBorneBas.value = sliderBorneHaut.value - Random.Range(10, 25);
        resulText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Appelle la fonction qui permet de vérifier si l'utilisateur à cliqué au bon endroit
            VerifSlide();
        }
    }

    void FixedUpdate()
    {
        Debug.Log(manager.currentState);
        //Fait bouger le slider tant que stopSlide est sur false
        if (!stopSlide)
        {
            ActiveSlide();
        }
        else
        {
            manager.currentState = States.Identify;
            gameObject.SetActive(false);
            adaptiveMusic.ResetMusicAdapt();
        }
    }

    void ActiveSlide()
    {
        //Vérifie la valeur du slider et détermine le sens de celui-ci
        if (mainSlider.value >= 100)
        {
            signePas = false;
            pas = -pas;
        }
        else if (mainSlider.value <= 0)
        {
            signePas = true;
            pas = Mathf.Abs(pas);
        }
        mainSlider.value += pas;
    }

    void VerifSlide()
    {
        //Si le slider est dans la bonne range
        if (mainSlider.value >= SliderBorneBas.value && mainSlider.value <= sliderBorneHaut.value && manager.currentState != States.Roam)
        {
            //stopSlide = true;
            resulText.text = "Ok !";
            ROckTop.GetComponent<Rigidbody>().useGravity = true;
            manager.currentState = States.Identify;
            resulText.text = "";
        }
        else
        {
            /*sliderBorneHaut.value = Random.Range(25, 80);
            SliderBorneBas.value = sliderBorneHaut.value - Random.Range(10, 25);
            if (pas <= 3.2f || pas >= -3.2f) //Augmente la vitesse jusqu'a un certain point
            {
                if (pas < 0)
                {
                    pas += -0.2f;
                }
                else
                {
                    pas += 0.2f;
                }
            }*/
            
            resulText.text = "Pas bon !";
            //Inverse le sens du slider
            if (signePas)
            {
                pas = -pas;
            }
            else
            {
                pas = Mathf.Abs(pas);
            }
        }
    }
}