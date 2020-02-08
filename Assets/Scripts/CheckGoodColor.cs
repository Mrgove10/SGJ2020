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
    private List<Vector3> _posWin = new List<Vector3>(); 
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
            if(_posWin.Count > 0)
            {

                Debug.Log(_posWin[0]);
                Debug.Log(positionClicked);
                Debug.Log(_posWin[0].x + clickOffset <= positionClicked.x && positionClicked.x <= _posWin[0].x - clickOffset);
                Debug.Log(_posWin[0].y + clickOffset < positionClicked.y && positionClicked.y < _posWin[0].y - clickOffset);
                if ((positionClicked.x + clickOffset <= _posWin[0].x  && positionClicked.y + clickOffset <= _posWin[0].y )
                    &&  (positionClicked.x - clickOffset >= _posWin[0].x  && positionClicked.y - clickOffset >= _posWin[0].x ))
                {
                    //do not count
                    Debug.Log("Do not count");
                    return;
                }

            }
            foreach (Color color in colorsClicked)
            {
                if (maxGoodColor.r >= color.r && maxGoodColor.g >= color.g && maxGoodColor.b >= color.b &&
                minGoodColor.r <= color.r && minGoodColor.g <= color.g && minGoodColor.b <= color.b 
                && _isWin == false)
                {
                    _posWin.Add(positionClicked);
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
            //age du minerais (range) -> 
            //nb de minerais analyser (reussite)
            //affichage incertitude
            //
            //diminue le score (rater)
            //
            Random.Range(23, 38);
            //Instantiate(showMineralUI, positionClicked, Quaternion.identity);
            _isWin = false;

        }
    }
}
