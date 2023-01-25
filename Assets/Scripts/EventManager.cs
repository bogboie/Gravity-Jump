using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public delegate void PlayerRespawn();
    public static event PlayerRespawn OnRespawn;
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Start is call
    public static void CallRespawn () {
      if (OnRespawn != null) {
        OnRespawn();
      }
    }
}
