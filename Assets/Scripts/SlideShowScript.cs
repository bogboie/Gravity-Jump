using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideShowScript : MonoBehaviour
{
    [SerializeField] private GameObject[] slides = new GameObject[100];
    [SerializeField] private int slide_count = 0;
    public int current_slide = 0;

    // Start is called before the first frame update
    void Start()
    {
        current_slide = 0;
        while (true)
        {
            GameObject slide = slides[slide_count];

            if (slide == null)
            {
                break;
            } else
            {
                slide_count++;
            }
        }
    }
   
    public void Next_Slide()
    {
        slides[current_slide].SetActive(false); 
        current_slide++;
        if (current_slide == slide_count)
        {
            // we know thta we are in the last slide and should continue to next scene
            EventManager.NextScene();
        }
        slides[current_slide].SetActive(true);
        
    }
}
