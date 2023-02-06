using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public delegate void EmptyEvent();
    public static event EmptyEvent OnRespawn;
    public static event EmptyEvent OnSceneClose;
    public static void NextScene()
    {
        if (OnSceneClose != null)
        {
            OnSceneClose();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public static  void GoToStartingScene()
    {
        if (OnSceneClose != null)
        {
            OnSceneClose();
        }
        SceneManager.LoadScene(1);
    }
    // Start is call
    public static void CallRespawn () {
      if (OnRespawn != null) {
        OnRespawn();
      }
    }
}
