using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Waypoint : MonoBehaviour
{
    public RectTransform prefab;

    private RectTransform waypoint;
    public Transform player;

    private TMP_Text distanceText;

    // Start is called before the first frame update
    void Start()
    {
        //   var canvas = this; GameObject.Find("Waypoints").transform;

        // waypoint = Instantiate(prefab, this.transform);

        distanceText = waypoint.GetComponentInChildren<TMP_Text>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        var screenPos = Camera.main.WorldToScreenPoint(position);
        waypoint.position = screenPos;
        distanceText.text = (int) Vector3.Distance(player.position, position) + " m";
    }
}