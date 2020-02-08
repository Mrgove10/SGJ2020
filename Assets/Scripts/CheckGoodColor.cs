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


    public RandomizeImage rng;
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
            //PopUP = le texte qui s'affiche a l'emplacement du clic
            if (_popUP != null)
            {
                Destroy(_popUP);
            }
            Debug.Log(rng.randomX);
            Debug.Log(rng.randomY);

            //Je recup les couleurs autour du pixel cliqué
            Color[] colorsClicked = GetComponent<SpriteRenderer>().sprite.texture.GetPixels((int)Input.mousePosition.x - rng.minX, (int)Input.mousePosition.y , clickOffset, clickOffset);

            //La couleur du pixel cliqué
            Color colorClicked = GetComponent<SpriteRenderer>().sprite.texture.GetPixel((int)Input.mousePosition.x, (int)Input.mousePosition.y);

            //position de ce pixel dans la camera
            Vector3 positionClicked = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            var worldPos = Camera.main.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);

            Debug.Log("color of the pixel clicked = " + GetComponent<SpriteRenderer>().sprite.texture.GetPixel((int)Input.mousePosition.x, (int)Input.mousePosition.y));

            //je creer mes couleurs bornes
            var maxGoodColor = GoodColor;
            var minGoodColor = GoodColor;
            maxGoodColor.r += tolerence;
            maxGoodColor.g += tolerence;
            maxGoodColor.b += tolerence;
            minGoodColor.r -= tolerence;
            minGoodColor.g -= tolerence;
            minGoodColor.b -= tolerence;

            //Si j'ai deja cliqué sur une bonne couleur
            if(_posWin.Count > 0)
            {
                //Debug.Log(_posWin[0]);
                //Debug.Log(positionClicked);
                Debug.Log(positionClicked.x <= _posWin[0].x - clickOffset || positionClicked.x >= _posWin[0].x + clickOffset);
                Debug.Log(positionClicked.y <= _posWin[0].y - clickOffset || positionClicked.y >= _posWin[0].y + clickOffset);
                if (!(positionClicked.x <= _posWin[0].x - clickOffset*2 || positionClicked.x >= _posWin[0].x + clickOffset*2)
                    && !(positionClicked.y <= _posWin[0].y - clickOffset*2 || positionClicked.y >= _posWin[0].y + clickOffset*2))
                {
                    //do not count
                    Debug.Log("Do not count");
                    return;
                }

            }

            //Je parcourt mon tableau de couleurs
            foreach (Color color in colorsClicked)
            {
                //Si la couleur que je regarde dans le tab correspond a une bonne couleur
                if (maxGoodColor.r >= color.r && maxGoodColor.g >= color.g && maxGoodColor.b >= color.b &&
                minGoodColor.r <= color.r && minGoodColor.g <= color.g && minGoodColor.b <= color.b 
                && _isWin == false)
                {
                    _posWin.Add(positionClicked);
                    _isWin = true;
                    Debug.Log("Trouver " + _posWin.Count);
                }
            }
            if (_posWin.Count == 2)
            {
                Debug.Log("deux trouver GG");
            }
            Debug.Log(positionClicked);

            //J'instacie ma popup avec mon texte (pour le moment c'est du lorem)
            var popUPgameObject = Instantiate(showMineralUI, positionClicked, Quaternion.identity);
            var popUPText = popUPgameObject.GetComponentInChildren<TMP_Text>();
            popUPText.transform.position = positionClicked;
            popUPText.text = Random.Range(0, 15).ToString();
            _popUP = popUPgameObject;

            //repase is win a false
            _isWin = false;

        }
    }
}
