using System;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public int points;

    public int time = 250;

    public States currentState = States.Roam;

    [Header("GameObjects")]
    public GameObject DefaultView;

    public GameObject FPSView;

    private void Start()
    {
        InvokeRepeating(nameof(RemoveTime), 1.0f, 1.0f);
    }

    private void Update()
    {
        switch (currentState)
        {
            case States.Roam:
                Camera.main.transform.position = DefaultView.transform.position;
                break;
            case States.Break:
                Camera.main.transform.position = FPSView.transform.position;
                break;
            case States.Slice:
                Camera.main.transform.position = FPSView.transform.position;
                break;
            case States.Identify:
                Camera.main.transform.position = FPSView.transform.position;
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

    public void GameOver()
    {
        Debug.Log("GAMEOVER");
    }
}