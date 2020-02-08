using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementMusicScript : MonoBehaviour
{
    public AudioSource audioMouvement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("right") || Input.GetKey("left") || Input.GetKey("z") || Input.GetKey("q") || Input.GetKey("s") || Input.GetKey("d"))
        {
            audioMouvement.volume = 0.3f;
        }
        else
        {
            audioMouvement.volume = 0;
        }
    }
}
