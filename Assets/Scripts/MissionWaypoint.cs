using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionWaypoint : MonoBehaviour
{
    // Indicator icon
    public Image img;
    public List<GameObject> imgs = new List<GameObject>();
    // The target (location, enemy, etc..)
    public Transform[] targets;
    // UI Text to display the distance
    public TMP_Text meter;
    // To adjust the position of the icon
    public Vector3 offset;

    public GameObject canvas;

    private void Start()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            imgs.Add(Instantiate(img.gameObject,canvas.transform));
            imgs[i].gameObject.SetActive(true);
        }
    }


    private void Update()
    {
        
        for (int i= 0; i < targets.Length; i++)
        {
            // Giving limits to the icon so it sticks on the screen
            // Below calculations witht the assumption that the icon anchor point is in the middle
            // Minimum X position: half of the icon width
            float minX = imgs[i].GetComponent<Image>().GetPixelAdjustedRect().width / 2;
            // Maximum X position: screen width - half of the icon width
            float maxX = Screen.width - minX;

            // Minimum Y position: half of the height
            float minY = imgs[i].GetComponent<Image>().GetPixelAdjustedRect().height / 2;
            // Maximum Y position: screen height - half of the icon height
            float maxY = Screen.height - minY;
            // Temporary variable to store the converted position from 3D world point to 2D screen point
            Vector2 pos = Camera.main.WorldToScreenPoint(targets[i].position + offset);

            // Check if the target is behind us, to only show the icon once the target is in front
            if (Vector3.Dot((targets[i].position - transform.position), transform.forward) < 0)
            {
                // Check if the target is on the left side of the screen
                if (pos.x < Screen.width / 2)
                {
                    // Place it on the right (Since it's behind the player, it's the opposite)
                    pos.x = maxX;
                }
                else
                {
                    // Place it on the left side
                    pos.x = minX;
                }
            }

            // Limit the X and Y positions
            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);

            // Update the marker's position
            imgs[i].GetComponent<Image>().transform.position = pos;
            // Change the meter text to the distance with the meter unit 'm'
            if(((int)Vector3.Distance(targets[i].position, transform.position)) < 20)
            {
                imgs[i].GetComponentInChildren<TMP_Text>().text = "";
            }
            else
            {
                imgs[i].GetComponentInChildren<TMP_Text>().text = ((int)Vector3.Distance(targets[i].position, transform.position)).ToString() + "m";
            }
        }

        
    }
}
