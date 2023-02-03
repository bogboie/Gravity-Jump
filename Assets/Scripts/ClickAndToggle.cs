using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndToggle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject other;
    public double radius;
    private 
    void Start()
    {
        
    }
    float Dist(Vector2 a, Vector2 b)
    {
        return (a - b).magnitude;
    }
    public void OnMouseDown()
    {
        gameObject.SetActive(false);
        AudioFX.Toggle();
        other.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == UnityEngine.TouchPhase.Began)
            {
                float dist = Dist(touch.position, transform.position);
                if (dist < 60)
                {
                    gameObject.SetActive(false);
                    AudioFX.Toggle();
                    other.SetActive(true);

                }
            }
        }
    }
}
