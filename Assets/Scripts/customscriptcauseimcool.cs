using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customscriptcauseimcool : MonoBehaviour
{
    float timeSpentOnDoingNothing = 0f;
    public float LoadingTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSpentOnDoingNothing += Time.deltaTime;
        if (timeSpentOnDoingNothing >= LoadingTime)
        {
            EventManager.GoToStartingScene();
        }
    }
}
