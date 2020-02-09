using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickScript : MonoBehaviour
{
    public List<Button> buttons;
    public Manager manager;

    public MusicManager musicManager;

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
        musicManager.SonBon1F();
    }

    public void buttonFunction1()
    {
        clicks++;
        musicManager.SonBon1F();
    }

    public void buttonFunction2()
    {
        clicks++;
        musicManager.SonBon1F();
    }

    public void buttonFunction3()
    {
        clicks++;
        musicManager.SonBon1F();
    }

    public void buttonFunction4()
    {
        clicks++;
        musicManager.SonBon1F();
    }

    public void buttonFunction5()
    {
        clicks++;
        musicManager.SonBon1F();
    }

    public void buttonFunction6()
    {
        clicks++;
        musicManager.SonBon1F();
    }

    public void buttonFunction7()
    {
        clicks++;
        musicManager.SonBon1F();
    }
    public void buttonFunction8()
    {
        clicks++;
        musicManager.SonBon1F();
    }
    public void buttonFunction9()
    {
        clicks++;
        musicManager.SonBon1F();
    }

    // Update is called once per frame
    void Update()
    {
        musicManager.SonBon2F();
        if (clicks >=2)
        {
            manager.currentState = States.Roam;
            clicks = 0;
            manager.nbGisement ++;
            if (manager.player.objInteractWith.GetComponent<Rock>().timeAdder)
            {
                manager.time += 10;
            }
            else
            {
                manager.points += 150;
            }
            Destroy(manager.player.objInteractWith);
            manager.player.objInteractWith = null;

        } 
    }        
}