using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickScript : MonoBehaviour
{
    public List<Button> buttons;
    // Start is called before the first frame update
    void Start()
    {
        buttons[0].onClick.AddListener(buttonFunction);
        buttons[1].onClick.AddListener(buttonFunction);
        buttons[2].onClick.AddListener(buttonFunction);
        buttons[3].onClick.AddListener(buttonFunction);
        buttons[4].onClick.AddListener(buttonFunction);
        buttons[5].onClick.AddListener(buttonFunction);
        buttons[6].onClick.AddListener(buttonFunction);
        buttons[7].onClick.AddListener(buttonFunction);
        buttons[8].onClick.AddListener(buttonFunction);
        buttons[9].onClick.AddListener(buttonFunction);
    }

    public void buttonFunction() {
        Debug.Log("TEST");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
