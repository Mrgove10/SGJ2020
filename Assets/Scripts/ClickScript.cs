using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickScript : MonoBehaviour
{
    public List<Button> buttons;

    public int clicks;
    // Start is called before the first frame update
    void Start()
    {
        buttons[0].onClick.AddListener(buttonFunction0);
        buttons[1].onClick.AddListener(buttonFunction1);
        buttons[2].onClick.AddListener(buttonFunction2);
        buttons[3].onClick.AddListener(buttonFunction3);
        buttons[4].onClick.AddListener(buttonFunction4);
        buttons[5].onClick.AddListener(buttonFunction5);
        buttons[6].onClick.AddListener(buttonFunction6);
        buttons[7].onClick.AddListener(buttonFunction7);
        buttons[8].onClick.AddListener(buttonFunction8);
        buttons[9].onClick.AddListener(buttonFunction9);
    }

    public void buttonFunction0()
    {
        clicks++;
    }

    public void buttonFunction1()
    {
        clicks++;
    }

    public void buttonFunction2()
    {
        clicks++;
    }

    public void buttonFunction3()
    {
        clicks++;
    }

    public void buttonFunction4()
    {
        clicks++;
    }

    public void buttonFunction5()
    {
        clicks++;
    }

    public void buttonFunction6()
    {
        clicks++;
    }

    public void buttonFunction7()
    {
        clicks++;
    }
    public void buttonFunction8()
    {
        clicks++;
    }
    public void buttonFunction9()
    {
        clicks++;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(clicks);
    }        
}