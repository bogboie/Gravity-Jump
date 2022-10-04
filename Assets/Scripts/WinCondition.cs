using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinCondition : MonoBehaviour
{
    public TMP_Text Win_Text;
    private void Start()
    {
        Win_Text.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.tag);
       if (other.gameObject.tag == "Player")
        {
            Win_Text.enabled = true;
        }
    }
}
