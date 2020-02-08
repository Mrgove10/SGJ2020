using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Manager manager;

    [Header("objects")]
    public GameObject MainUI;

    public TMP_Text timeText;
    public TMP_Text scoreText;

    public GameObject BreakUI;
    public GameObject SliceUI;
    public GameObject ClickUI;

    private void Update()
    {
        timeText.text = manager.time.ToString();
        scoreText.text = manager.points.ToString();

        switch (manager.currentState)
        {
            case States.Roam:
                MainUI.SetActive(true);
                BreakUI.SetActive(false);
                SliceUI.SetActive(false);
                ClickUI.SetActive(false);
                break;
            case States.Break:
                MainUI.SetActive(false);
                BreakUI.SetActive(true);
                SliceUI.SetActive(false);
                ClickUI.SetActive(false);
                break;
            case States.Slice:
                MainUI.SetActive(false);
                BreakUI.SetActive(false);
                SliceUI.SetActive(true);
                ClickUI.SetActive(false);
                break;
            case States.Identify:
                MainUI.SetActive(false);
                BreakUI.SetActive(false);
                SliceUI.SetActive(false);
                ClickUI.SetActive(true);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}