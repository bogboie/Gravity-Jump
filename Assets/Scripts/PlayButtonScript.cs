using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayButtonScript : MonoBehaviour
{
    public void Start_Level_1() {
        EventManager.GoToD0L0();
    }
    public void Start_Settings()
    {
        EventManager.GoToSettingsScene();
    }

}
