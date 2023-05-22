using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleFallingDownScreenUI : MonoBehaviour
{
    private Slider slider;
    private GameObject player;
    private GameObject endGoal;
    private Vector3 startPos;
    private Vector3 endPos;

    void Start()
    {
        if (this.transform.position != GameObject.Find("Starting position").transform.position)
        {
            print("Script <AppleFallingDownScreenUI> should be be attached to the starting position object");
        }
        slider = GameObject.Find("HeightSlider").GetComponent<Slider>();
        player = GameObject.Find("Apple");
        endGoal = GameObject.Find("Win");

        startPos = transform.position;
        endPos = endGoal.transform.position;
    }


    void Update()
    {
        float percentDown = (Mathf.Abs(startPos.y - player.transform.position.y)) / (Mathf.Abs(startPos.y - endPos.y));

        slider.value = percentDown;
    }
}
