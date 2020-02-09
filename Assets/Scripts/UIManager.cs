using System;
using TMPro;
using UnityEngine;
using Random = System.Random;

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

                var txt = @"Bravo!

                    Vous avez réussi à analyser XX gisements métalliques.
                L'âge ainsi calculé est de XXXX Millions d'années
                    (cet âge correspond à la collision alpine).


                Rejouez pour améliorer la précision de votre âge
                en datant encore plus de gisements !
                    ";

                txt.Replace("XX", nbgisement.ToString());
                txt.Replace("XXXX", nbgisement.ToString());
                EndUI.GetComponentInChildren<TMP_Text>().text = txt;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}