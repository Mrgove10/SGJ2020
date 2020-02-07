using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderScript : MonoBehaviour
{
    public Slider mainSlider;
    public Slider sliderBorneHaut;
    public Slider SliderBorneBas;
    public TextMeshPro resulText;
    public int pas;

    private bool signePas;
    private bool stopSlide;



    // Start is called before the first frame update
    void Start()
    {
        signePas = true;
        stopSlide = false;
        pas = 2;

        sliderBorneHaut.value = Random.Range(25, 80);
        SliderBorneBas.value = sliderBorneHaut.value - Random.Range(10, 25);
        resulText.text = "";
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            stopSlide = true;
        }
    }

    void FixedUpdate()
    {
        if (!stopSlide)
        {
            ActiveSlide();
        }
    }

    void ActiveSlide()
    {
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
        if(mainSlider.value >= SliderBorneBas.value && mainSlider.value <= sliderBorneHaut.value)
        {

        }
    }
}
