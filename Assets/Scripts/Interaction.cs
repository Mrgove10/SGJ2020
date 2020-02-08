using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Interaction : MonoBehaviour
{
    public Manager manager;
    public GameObject rock;

    private Random r;

    private void Start()
    {
        r = new Random();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var t = rock.transform.GetChild(r.Next(0, rock.transform.childCount));
            if (t.transform.name.Contains("polySurface"))
            {
                t.GetComponent<Rigidbody>().GetComponent<Rigidbody>().useGravity = true;
                StartCoroutine(deletebj(t.gameObject));
            }
        }

        if (manager.currentState == States.Break)
        {
            TurnObject();
        }

        if (rock.transform.childCount <= 2)
        {
            manager.currentState = States.Slice;
        }
    }

    IEnumerator deletebj(GameObject t)
    {
        if (t)
        {
            yield return new WaitForSeconds(0.5f);
            Destroy(t.gameObject);
        }
    }

    void TurnObject()
    {
        float rotationSpeed = 15;

        float xAxis = Input.GetAxis("Mouse X") * rotationSpeed;
        float yAxis = Input.GetAxis("Mouse Y") * rotationSpeed;

        rock.transform.Rotate(Vector3.up, -xAxis, Space.World);
        rock.transform.Rotate(Vector3.right, yAxis, Space.World);
    }
}