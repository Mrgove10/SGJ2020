using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestGetPixelColor : MonoBehaviour
{
    private MeshFilter plane;
    private void Start()
    {
        plane = GetComponent(typeof(MeshFilter)) as MeshFilter;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("color of the pixel clicked = " + GetComponent<SpriteRenderer>().sprite.texture.GetPixel((int)Input.mousePosition.x, (int)Input.mousePosition.y).grayscale);
            Debug.Log("color of the pixel clicked = " + GetComponent<SpriteRenderer>().sprite.texture.GetPixel((int)Input.mousePosition.x, (int)Input.mousePosition.y));
        }
    }

}
