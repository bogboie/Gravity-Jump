using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public delegate void EmptyEvent();
    public static event EmptyEvent OnRespawn;
    public static event EmptyEvent OnSceneClose;
    public static event EmptyEvent OnWin;

    public static void NextScene()
    {
        if (OnSceneClose != null)
        {
            OnSceneClose();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public static void GoToSettingsScene()
    {
        if (OnSceneClose != null)
        {
            OnSceneClose();
        }
        SceneManager.LoadScene(2);
    }
    public static void GoToLevelSelectScene()
    {
        if (OnSceneClose != null)
        {
            OnSceneClose();
        }
        SceneManager.LoadScene(1);
    }
    public static void GoToStartingScene()
    {
        if (OnSceneClose != null)
        {
            OnSceneClose();
        }
        SceneManager.LoadScene(0);
    }
    public static void GoToD0L0()
    {
        if (OnSceneClose != null)
        {
            OnSceneClose();
        }
        SceneManager.LoadScene(3);
    }
    // Start is call
    public static void CallRespawn () {
      if (OnRespawn != null) {
        OnRespawn();
      }
    }
    public static void CallOnWin() {
        if ( OnWin != null) {
            OnWin();
        }
    }
    public static void GoToTutorialScene()
    {
        if (OnSceneClose != null)
        {
            OnSceneClose();
        }
        SceneManager.LoadScene(1);
    }
    public static void GoToScene(int Scene_Number)
    {
        if (OnSceneClose != null)
        {
            OnSceneClose();
        }
        SceneManager.LoadScene(Scene_Number);
    }
}
