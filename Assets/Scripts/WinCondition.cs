using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    public TMP_Text Win_Text;
    public Button Next_Level_Button;
    private Vector3 hide_button = new Vector3(0, 1, 1);
    private Vector3 show_button = new Vector3(1, 1, 1);

    private void Start()
    {
        Win_Text.enabled = false;
        Next_Level_Button.transform.localScale = hide_button;
        Next_Level_Button.interactable = false;

    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Player")
        {
            Win_Text.enabled = true;
            Next_Level_Button.transform.localScale = show_button;
            Next_Level_Button.interactable = true;
        }
    }
}
