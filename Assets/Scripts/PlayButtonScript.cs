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
    public void Start_Tutorial()
    {
        EventManager.GoToTutorialScene();
    }
    public void NextLevel()
    {
        EventManager.NextScene();
    }
    public void Start_Level_Select()
    {
        EventManager.GoToLevelSelectScene();
    }
    public void Go_To_Info_Page()
    {
        EventManager.GoToScene(23);
    }
    public void GOTOHOUSE()
    {
        EventManager.GoToStartingScene();
    }
}
