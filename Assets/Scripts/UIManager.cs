using System;
using TMPro;
using UnityEngine;
using Random = System.Random;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Manager manager;

    [Header("objects")]
    public GameObject MainUI;

    public TMP_Text timeText;
    public TMP_Text scoreText;

    public GameObject BreakUI;
    public GameObject SliceUI;
    public GameObject ClickUI;
    public GameObject EndUI;

    private bool _once = false;
    private int age;
    private int pas;

    public Button mainMenuButton;
    

    private void Start()
    {
        mainMenuButton.onClick.AddListener(BackToMainMenu);
    }
    private void Update()
    {
        timeText.text = manager.time.ToString();
        scoreText.text = manager.points.ToString();

        switch (manager.currentState)
        {
            case States.Roam:
                MainUI.SetActive(true);
                BreakUI.SetActive(false);
                SliceUI.SetActive(false);
                ClickUI.SetActive(false);
                EndUI.SetActive(false);
                break;
            case States.Break:
                MainUI.SetActive(false);
                BreakUI.SetActive(true);
                SliceUI.SetActive(false);
                ClickUI.SetActive(false);
                EndUI.SetActive(false);
                break;
            case States.Slice:
                MainUI.SetActive(false);
                BreakUI.SetActive(false);
                SliceUI.SetActive(true);
                ClickUI.SetActive(false);
                EndUI.SetActive(false);
                break;
            case States.Identify:
                MainUI.SetActive(false);
                BreakUI.SetActive(false);
                SliceUI.SetActive(false);
                ClickUI.SetActive(true);
                EndUI.SetActive(false);
                break;
            case States.End:
                MainUI.SetActive(false);
                BreakUI.SetActive(false);
                SliceUI.SetActive(false);
                ClickUI.SetActive(false);
                EndUI.SetActive(true);
                var nbgisement = manager.nbGisement;
                var années = 0;
                Random r = new Random();
                if (nbgisement < 2)
                {
                }
                else if (2 < nbgisement && nbgisement < 5)
                {
                    années = r.Next(20, 50);
                }
                else if (6 < nbgisement && nbgisement < 10)
                {
                    années = r.Next(25, 45);
                }
                else if (11 < nbgisement && nbgisement < 15)
                {
                    années = r.Next(30, 40);
                }
                else if (nbgisement > 16)
                {
                    années = r.Next(34, 36);
                }

                var txt = @"
Votre score est de Z

Vous avez réussi à analyser XX gisements métalliques.
L'âge ainsi calculé est de Y Millions d'années 
+/- X Ma
(cet âge correspond à la collision alpine).


Rejouez pour améliorer la précision de votre âge
en datant encore plus de gisements !
                ";

                txt = txt.Replace("XX", nbgisement.ToString());
                if (nbgisement <= 5 && _once == false)
                {
                    _once = true;
                    age = UnityEngine.Random.Range(20,51);
                    pas = 15;
                }
                else if (nbgisement <= 10 && nbgisement > 5 && _once == false)
                {
                    age = UnityEngine.Random.Range(25,46);
                    pas = 10;
                }
                else if (nbgisement <= 15 && nbgisement > 10 && _once == false)
                {
                    pas = 5;
                    age = UnityEngine.Random.Range(30, 41);
                }
                else if (_once == false)
                {
                    pas = 1;
                    age = UnityEngine.Random.Range(34, 37);
                }
                Debug.Log(age);
                txt = txt.Replace("Y", age.ToString());
                txt = txt.Replace("X", pas.ToString());
                txt = txt.Replace("Z", manager.points.ToString());
                EndUI.GetComponentInChildren<TMP_Text>().text = txt;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void BackToMainMenu()
    {
        Debug.Log("tzsqt");
        SceneManager.LoadSceneAsync("MainMenu");
    }
}