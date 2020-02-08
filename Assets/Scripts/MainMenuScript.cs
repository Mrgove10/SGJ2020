﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;

#else
using UnityEngine;
#endif

public class MainMenuScript : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject creditsPanel;

    public Button boutonStart;
    public Button boutonFreeRoam;
    public Button boutonCredits;
    public Button boutonQuit;
    public Button boutonCreditResume;


    // Start is called before the first frame update
    void Start()
    {
        boutonStart.onClick.AddListener(StartGame);
        boutonFreeRoam.onClick.AddListener(StartFreeRom);
        boutonCredits.onClick.AddListener(StartCredits);
        boutonQuit.onClick.AddListener(QuitGame);
        boutonCreditResume.onClick.AddListener(ResumeCredits);

        creditsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    void StartFreeRom()
    {
        //A faire
        Debug.Log("On a cliqué sur FreeRoam !");
    }

    void StartCredits()
    {
        menuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    void QuitGame()
    {
        #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
        #else
                    Application.Quit();
        #endif
    }

    void ResumeCredits()
    {
        menuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
}