using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MonoBehaviour
{
    public PlayerMovement Player_Script;
    private void OnMouseDown()
    {
        Player_Script.Jump();
    }
}
