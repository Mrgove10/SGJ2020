using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public int points;

    public int time = 250;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("removeTime", 1.0f, 1.0f);
    }

    void removeTime()
    {
        if(time > 0) {
            time -= 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(time);
    }
}