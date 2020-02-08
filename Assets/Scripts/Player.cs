using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float clamp = 0.0025f;
    public Manager manager;
    public Animator Animator;
    public TMP_Text interactText;

    public AdaptiveMusicScript adaptiveMusic;

    public GameObject objInteractWith;
    public GameObject rockPrefab;
    public GameObject breakPrefab;


    private void Start()
    {
        interactText.gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        objInteractWith = null;
        interactText.gameObject.SetActive(false);
        adaptiveMusic.ResetMusicAdapt();
    }
    void OnTriggerEnter(Collider col)
    {
        objInteractWith = col.gameObject;
        interactText.gameObject.SetActive(true);
        Debug.Log(col);
        int randomMusic = Random.Range(1, 5);
        switch (randomMusic)
        {
            case 1:
                adaptiveMusic.melodiaPlayV1 = true;
                break;
            case 2:
                adaptiveMusic.melodiaPlayV2 = true;
                break;
            case 3:
                adaptiveMusic.melodiaPlayV3 = true;
                break;
            case 4:
                adaptiveMusic.melodiaPlayV4 = true;
                break;
            default:
                break;
        }
        //adaptiveMusic

        /*if (col.gameObject.CompareTag("Pickable"))
        {
            manager.currentState = States.Break;
        }*/
    }

    private void Update()
    {
        Animator.SetFloat("Blend X", Input.GetAxis("Horizontal"));
        Animator.SetFloat("Blend Y", Input.GetAxis("Vertical"));

        if (Input.GetKeyDown(KeyCode.Space) && objInteractWith && manager.currentState == States.Roam)
        {
            manager.currentState = States.Break;
            interactText.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.up * (Mathf.Cos(Time.time) * clamp) / 100; //float effect
    }
}