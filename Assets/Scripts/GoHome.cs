using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHome : MonoBehaviour
{
    // Start is called before the first frame update

    public void GoToHome()
    {
        EventManager.GoToStartingScene();
    }
    // Update is called once per frame
    public void StartD1()
    {
        EventManager.GoToScene(5);
    }
    public void StartD2()
    {
        EventManager.GoToScene(9);

    }
    public void StartD3()
    {
        EventManager.GoToScene(14);

    }
    public void StartD4()
    {
        EventManager.GoToScene(20);

    }
}
