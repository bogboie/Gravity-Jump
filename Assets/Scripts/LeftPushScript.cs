using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftPushScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    void Start()
    {
        Button button = gameObject.GetComponent<Button>();

        button.onClick.AddListener(PushPlayerLeft);
    }

    void PushPlayerLeft()
    {
        GameObject player = GameObject.Find("Apple");
        PlayerMovement script = player.GetComponent<PlayerMovement>();
        script.push_left();
    }

}
