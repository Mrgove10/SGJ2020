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


    private int _randomX;
    private int _randomY;
    private Vector3 _pos;
    // Start is called before the first frame update
    void Start()
    {
        _randomX = Random.Range(minX, maxX);
        _randomY = Random.Range(minY, maxY);
        _pos = new Vector3(_randomX, _randomY, 269);
        background.transform.position = _pos;
    }

}
