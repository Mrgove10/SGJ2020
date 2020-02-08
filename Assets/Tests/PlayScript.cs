using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayScript : MonoBehaviour
{
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        Button buttonOk = button.GetComponent<Button>();
        buttonOk.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        Debug.Log("Vous avez cliqué sur le bouton !");
        //mettre l'action que vous voulez ici !
    }
}
