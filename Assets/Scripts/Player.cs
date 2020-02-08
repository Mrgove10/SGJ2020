using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float clamp = 0.0025f;
    public Manager manager;
    public Animator Animator;
    public TMP_Text interactText;

    private bool _isInAreaOfObject = false;

    private void Start()
    {
        interactText.gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider col)
    {
        _isInAreaOfObject = true;
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

        if (Input.GetKeyDown(KeyCode.Space) && _isInAreaOfObject == true)
        {
            manager.currentState = States.Break;
            _isInAreaOfObject = false;
            interactText.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.up * (Mathf.Cos(Time.time) * clamp) / 100; //float effect
    }
}