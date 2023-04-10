using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pause()
    {
        //first when pauseing i need to pause the game that will become paused and in fact before the game is paused this pause function should be called once to pause the game right as it should be paused for an amount of time determined by the paused becuase the pause if a very usefull tool in pauseing the thing being paused.
        Time.timeScale = 0f;

    }
    public void UnPause()
    {
        Time.timeScale = 1;

    }
}
