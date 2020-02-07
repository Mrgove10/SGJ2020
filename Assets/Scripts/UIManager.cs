using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text timeText;
    public TMP_Text scoreText;
    public Manager manager;

    private void Update()
    {
        timeText.text = manager.time.ToString();
        scoreText.text = manager.points.ToString();
    }
}