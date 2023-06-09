using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightPushScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    void Start()
    {
        Button button = gameObject.GetComponent<Button>();

        button.onClick.AddListener(PushPlayerRight);
    }

    void PushPlayerRight()
    {
        GameObject player = GameObject.Find("Apple");
        PlayerMovement script = player.GetComponent<PlayerMovement>();
        script.push_right();
    }

}
