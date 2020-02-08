using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGoodColor : MonoBehaviour
{
    public Color GoodColor;
    [Range(0, 0.2f)]
    public float tolerence;
    public int clickOffset;

    private bool _isWin = false;
    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Color[] colorsClicked = GetComponent<SpriteRenderer>().sprite.texture.GetPixels((int)Input.mousePosition.x, (int)Input.mousePosition.y, clickOffset, clickOffset);
            //Debug.Log("color of the pixel clicked = " + GetComponent<SpriteRenderer>().sprite.texture.GetPixel((int)Input.mousePosition.x, (int)Input.mousePosition.y).grayscale);
            var maxGoodColor = GoodColor;
            var minGoodColor = GoodColor;
            maxGoodColor.r += tolerence;
            maxGoodColor.g += tolerence;
            maxGoodColor.b += tolerence;
            minGoodColor.r -= tolerence;
            minGoodColor.g -= tolerence;
            minGoodColor.b -= tolerence;
            foreach (Color color in colorsClicked)
            {
                if (maxGoodColor.r >= color.r && maxGoodColor.g >= color.g && maxGoodColor.b >= color.b &&
                minGoodColor.r <= color.r && minGoodColor.g <= color.g && minGoodColor.b <= color.b 
                && _isWin == false)
                {
                    _isWin = true;
                    Debug.Log("GG");
                }
            }
            _isWin = false;

        }
    }
}
