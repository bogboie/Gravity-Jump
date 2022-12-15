using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MonoBehaviour
{
    private GameObject Player;
    private PlayerMovement Player_Script;
    private void Awake() {
      Player = GameObject.FindWithTag("Player");
      Player_Script = Player.GetComponent<PlayerMovement>();
    }
    private void OnMouseDown()
    {
        Player_Script.Jump();
    }
}
