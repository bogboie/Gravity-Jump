using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    Slider volumeSlider;
    // Start is called before the first frame update
    public void Start()
    {
        Load();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }
    private void Load()
    {
        try
        {
            volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
            AudioListener.volume = volumeSlider.value;

        }
        catch (Exception)
        {
            AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
        }

    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }


}
