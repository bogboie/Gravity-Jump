using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Player")
        {
            print("Player WOn!!!!");
            EventManager.CallOnWin();
        }
    }
}
