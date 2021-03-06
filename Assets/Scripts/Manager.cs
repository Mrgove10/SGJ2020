﻿using System;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public int points;
    public int nbGisement;
    public int time = 250;

    public States currentState = States.Roam;

    [Header("GameObjects")]
    public GameObject DefaultView;

    public MusicManager musicManager;
    public Animator animation;
    public UIManager uiManager;


    public GameObject FPSView;
    private Camera mainCamera;

    public GameObject planet;
    public GameObject rock;

    public GameObject endGame;
    public GameObject hud;

    public GameObject sliceUI;

    private bool _once1;
    private bool _once2;
    private bool _once3;
    private bool _onceinstanciate;
    public Player player;

    public GameObject steins;

    public Texture eyesUpdate;
    public Texture eyesDead;
    public Texture eyesDiamond;
    public Texture eyesStein;
    public Texture eyesPac;
    public Texture eyesUnlock;



    private void Start()
    {
        steins.GetComponent<Renderer>().material.SetTexture("_EmissionMap", eyesStein);
        mainCamera = Camera.main;
        InvokeRepeating(nameof(RemoveTime), 1.0f, 1.0f);
        _once1 = true;
        _once2 = true;
        _once3 = true;
        _onceinstanciate = true;
    }

    private void Update()
    {
        switch (currentState)
        {
            case States.Roam:
                
                ShowMainHUD();
                mainCamera.transform.position = DefaultView.transform.position;
                ShowElements();
                _once1 = true;
                _once2 = true;
                _onceinstanciate = true;
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
                HideMainHUD();
                if (_once1)
                {
                    animation.SetInteger("Arm Open", 1);
                    musicManager.SonParleF();
                    musicManager.SonDeplisBrasF();
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
                    sliceUI.GetComponentInChildren<Slice>().randomizer();
                    animation.SetInteger("Arm Open", 0);
                    animation.SetInteger("Arm Close", 1);
                    musicManager.SonParleF();
                    _once2 = false;
                }

                break;
            case States.Identify:
                _once2 = true;
                endGame.SetActive(true);
                mainCamera.transform.position = FPSView.transform.position;
                HideElements();
                if (_onceinstanciate)
                {
                    player.rockPrefab = Instantiate(player.BackupRockPrefab,player.breakPrefab.transform);
                    player.GetComponent<Break>().rock = player.rockPrefab; 
                    _onceinstanciate = false;
                    musicManager.SonTranchePierreF();
                    musicManager.SonReplisBrasF();
                }

                break;
            case States.End:
                Debug.Log("end game (back to main menue button to add)");
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
        if (time == 5)
        {
            steins.GetComponent<Renderer>().material.SetTexture("_EmissionMap", eyesDead);
        }
        else
        {

            steins.GetComponent<Renderer>().material.SetTexture("_EmissionMap", eyesStein);
        }
    }

    private void GameOver()
    {
        steins.GetComponent<Renderer>().material.SetTexture("_EmissionMap", eyesUnlock);
        Debug.Log("Game over");
        currentState = States.End;
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

    private void HideMainHUD()
    {
        hud.SetActive(false);
    }

    private void ShowMainHUD()
    {
        hud.SetActive(true);
    }
}