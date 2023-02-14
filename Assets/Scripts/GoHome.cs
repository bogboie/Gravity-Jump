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

}
