using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenuScript : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject creditsPanel;

    public Button boutonStart;
    public Button boutonFreeRoam;
    public Button boutonCredits;
    public Button boutonQuit;
    public Button boutonCreditResume;

    public Animator robotAnimator;

    // Start is called before the first frame update
    void Start()
    {
        boutonStart.onClick.AddListener(StartGame);
        boutonFreeRoam.onClick.AddListener(StartFreeRom);
        boutonCredits.onClick.AddListener(StartCredits);
        boutonQuit.onClick.AddListener(QuitGame);
        boutonCreditResume.onClick.AddListener(ResumeCredits);

        creditsPanel.SetActive(false);

        InvokeRepeating(nameof(Animation), 1f, 7f);
    }

    void Animation()
    {
        robotAnimator.SetInteger("Emote", 1);
        Debug.Log("Annimation Launched");
    }

    void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    void StartFreeRom()
    {
        //A faire
        Debug.Log("On a cliqué sur FreeRoam !");
    }

    void StartCredits()
    {
        menuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
                    Application.Quit();
#endif
    }

    void ResumeCredits()
    {
        menuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
}