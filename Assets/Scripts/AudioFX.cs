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


    public static void Play(AudioSource audio)
    {
        if (Muted) { return; }
        if (audio == null)
        {
            Console.WriteLine("AUDIOSOURCE IS NULL!!!");
            
            return;
        }

        audio.Play();
    }
    

}
