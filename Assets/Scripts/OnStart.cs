using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStart : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
        EventManager.GoToScene(24);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
