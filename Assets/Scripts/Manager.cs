using System;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public int points;

    public int time = 250;

    public States currentState = States.Roam;

    [Header("GameObjects")]
    public GameObject DefaultView;
    public MusicManager musicManager;
    public Animator animation;
    
    public GameObject FPSView;
    private Camera mainCamera;

    public GameObject planet;
    public GameObject rock;

    private bool _once1;
    private bool _once2;
    private bool _once3;
    public Player player;


    private void Start()
    {
        mainCamera = Camera.main;
        InvokeRepeating(nameof(RemoveTime), 1.0f, 1.0f);
        _once1 = true;
        _once2 = true;
        _once3 = true;
    }

    private void Update()
    {
        switch (currentState)
        {
            case States.Roam:
                mainCamera.transform.position = DefaultView.transform.position;
                ShowElements();
                _once1 = true;
                _once2 = true;
                if (_once3)
                {
                    musicManager.SonContentF();
                    _once3 = false;
                }
                break;
            case States.Break:
                mainCamera.transform.position = FPSView.transform.position;
                mainCamera.fieldOfView = 73;
                ShowElements();
                if (_once1)
                {
                    animation.SetInteger("Arm Open",1);
                    musicManager.SonParleF();
                    _once1 = false;
                    _once3 = true;
                }
                break;
            case States.Slice:
                mainCamera.transform.position = FPSView.transform.position;
                mainCamera.fieldOfView = 60;
                ShowElements();
                if (_once2)
                {
                    
                    animation.SetInteger("Arm Open",0);
                    animation.SetInteger("Arm Close",1);
                    musicManager.SonParleF();
                    _once2 = false;
                }
                break;
            case States.Identify:
                mainCamera.transform.position = FPSView.transform.position;
                HideElements();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void RemoveTime()
    {
        if (time > 0)
        {
            time -= 1;
        }
        else if (time <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("GAMEOVER");
    }

    private void HideElements()
    {
        planet.SetActive(false);
        rock.SetActive(false);
    }

    private void ShowElements()
    {
        planet.SetActive(true);
        rock.SetActive(true);
    }
}