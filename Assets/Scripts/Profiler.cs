using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Profiler : MonoBehaviour
{
    public static bool show = true;
    private int framesToWait = 30;
    private int framesLeft;
    private double previousTime;
    [SerializeField]
    private double fps;
    [SerializeField]
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    private void Start()
    {
        previousTime = 0;
        framesLeft = framesToWait;
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        framesLeft--;
        if (framesLeft == 0)
        {
            fps = framesToWait / (Time.time - previousTime);
            if (show)
            {
                text.text = Mathf.Round((float)fps).ToString();
            }
            framesLeft = framesToWait;
            previousTime = Time.time;
        }
    }
    
}
