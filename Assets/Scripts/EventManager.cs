using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void PlayerRespawn();
    public static event PlayerRespawn OnRespawn;

    // Start is call
    public static void CallRespawn () {
      if (OnRespawn != null) {
        OnRespawn();
      }
    }
}
