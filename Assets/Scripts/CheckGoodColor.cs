using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckGoodColor : MonoBehaviour
{
    public Color GoodColor;
    [Range(0, 0.2f)]
    public float tolerence;
    public int clickOffset;
    public GameObject showMineralUI;

    private bool _isWin = false;
    private GameObject _popUP;
    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_popUP != null)
            {
                Destroy(_popUP);
            }
            Color[] colorsClicked = GetComponent<SpriteRenderer>().sprite.texture.GetPixels((int)Input.mousePosition.x, (int)Input.mousePosition.y, clickOffset, clickOffset);
            Color colorClicked = GetComponent<SpriteRenderer>().sprite.texture.GetPixel((int)Input.mousePosition.x, (int)Input.mousePosition.y);
            Vector3 positionClicked = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            var worldPos = Camera.main.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
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
            Debug.Log(positionClicked);
            var popUPgameObject = Instantiate(showMineralUI, positionClicked, Quaternion.identity);
            var popUPText = popUPgameObject.GetComponentInChildren<TMP_Text>();
            popUPText.transform.position = positionClicked;
            popUPText.text = Random.Range(0, 15).ToString();
            _popUP = popUPgameObject;
            //Instantiate(showMineralUI, positionClicked, Quaternion.identity);
            _isWin = false;

        }
    }
}
