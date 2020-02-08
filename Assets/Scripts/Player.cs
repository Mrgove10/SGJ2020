using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float clamp = 0.0025f;
    public Manager manager;
    public Animator Animator;
    public TMP_Text interactText;

    public GameObject objInteractWith;

    private void Start()
    {
        interactText.gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        objInteractWith = null;
        interactText.gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider col)
    {
        objInteractWith = col.gameObject;
        interactText.gameObject.SetActive(true);
        Debug.Log(col);
        /*if (col.gameObject.CompareTag("Pickable"))
        {
            manager.currentState = States.Break;
        }*/
    }

    private void Update()
    {
        Animator.SetFloat("Blend X", Input.GetAxis("Horizontal"));
        Animator.SetFloat("Blend Y", Input.GetAxis("Vertical"));

        if (Input.GetKeyDown(KeyCode.Space) && objInteractWith)
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