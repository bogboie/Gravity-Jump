using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class data : MonoBehaviour
{
    public int start_count = PlayerPrefs.GetInt("Startup Count") + 1;
    void Awake()
    {
        PlayerPrefs.SetInt("Startup Count",start_count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
