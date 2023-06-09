using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    PauseScript pauseScript;
    void Start()
    {
        GameObject pauseMenuScreen = GameObject.Find("Pause");
        pauseScript = pauseMenuScreen.GetComponent<PauseScript>();  
    }

    public void StartPause() 
    {        
        pauseScript.Pause();
    }
}
