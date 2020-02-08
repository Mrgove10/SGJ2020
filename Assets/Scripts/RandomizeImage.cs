using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomizeImage : MonoBehaviour
{
    public int maxX;
    public int maxY;
    public int minX;
    public int minY;

    public GameObject background;


    public int randomX;
    public int randomY;

    private Vector3 _pos;

    // Start is called before the first frame update
    void Start()
    {
        randomX = Random.Range(minX, maxX);
        randomY = Random.Range(minY, maxY);
        _pos = new Vector3(randomX, randomY, 269);
        background.transform.position = _pos;
    }
}