using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class jesaispascequejefais : MonoBehaviour
{
    public RectTransform prefab;

    private RectTransform waypoint;
    // Start is called before the first frame update
    void Start()
    {
        var canvas = GameObject.Find("Waypoints").transform;
        waypoint = Instantiate(prefab, canvas);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
