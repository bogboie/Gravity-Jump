using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayButtonScript : MonoBehaviour
{
    public void Start_Level_1() {
      SceneManager.LoadScene(1);
    }

}
