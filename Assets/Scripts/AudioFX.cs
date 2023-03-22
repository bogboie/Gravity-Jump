using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioFX : MonoBehaviour
{
    private static MissingReferenceException err = new MissingReferenceException("Null Audio Source");
    public static void Mute()
    {
        PlayerPrefs.SetInt("SFXMuted", 1);
    }
    public static void UnMute()
    {
        PlayerPrefs.SetInt("SFXMuted", 0);
    }
    public static void Toggle()
    {

        int current = PlayerPrefs.GetInt("SFXMuted");
        if (current == 1)
        {
            PlayerPrefs.SetInt("SFXMuted", 0);
        } else
        {
            PlayerPrefs.SetInt("SFXMuted", 1);
        }
        print("Audio FX Mute toggled to <" + current.ToString() + ">");
    }


    public static void Play(AudioSource audio)
    {
        int Muted = PlayerPrefs.GetInt("SFXMuted");
        if (audio == null)
        {
            //print("Audio FX Manager has been given an audio Source which identifies as <null>");
            throw err;
        }
        if (Muted == 1) { return; }
        audio.Play();
    }
    

}
