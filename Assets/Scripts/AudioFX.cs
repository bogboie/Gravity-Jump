using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioFX : MonoBehaviour
{
    private static bool Muted = false;

    public static void Mute()
    {
        Muted = true;
    }
    public static void UnMute()
    {
        Muted = false;
    }
    public static void Toggle()
    {
        Muted = !Muted;
        print("Audio FX Mute toggled to <" + Muted.ToString() + ">");
    }


    public static void Play(AudioSource audio)
    {
        if (audio == null)
        {
            print("Audio FX Manager has been given an audio Source which identifies as <null>");   
            return;
        }
        if (Muted) { return; }
        audio.Play();
    }
    

}
