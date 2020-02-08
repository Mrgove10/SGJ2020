using System.Collections;
using UnityEngine;
using Random = System.Random;

public class Break : MonoBehaviour
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
        if (manager.currentState != States.Break)
        {
            rock.SetActive(false);
        }

        if (manager.currentState == States.Break || manager.currentState == States.Slice)
        {
            rock.SetActive(true);
            TurnObject();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var t = rock.transform.GetChild(r.Next(0, rock.transform.childCount));
            if (t.transform.name.Contains("polySurface"))
            {
                t.GetComponent<Rigidbody>().GetComponent<Rigidbody>().useGravity = true;
                StartCoroutine(deletebj(t.gameObject));
            }
        }

        // no mode pieces left
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