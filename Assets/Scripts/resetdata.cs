using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetdata : MonoBehaviour
{
    // Start is called before the first frame update
    public void RESET()
    {
        PlayerPrefs.SetFloat("musicVolume",1.0f);
        PlayerPrefs.SetInt("Dimensions",0);
    }
}
