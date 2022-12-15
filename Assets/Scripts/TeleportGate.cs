using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportGate : MonoBehaviour
{
    private GameObject Player;
    public GameObject other_Gate;
    private TeleportGate other_Gate_Script;
    private Transform Player_Transform;
    public bool Gate_Locked = false;
    private string _tag;

    private void Awake()
    {
        Player = GameObject.FindWithTag("Player");
        Player_Transform = Player.GetComponent<Transform>();
        other_Gate_Script = other_Gate.GetComponent<TeleportGate>();

    }
    public void OnTriggerEnter(Collider other)
    {
        if (Gate_Locked) { return; }
        _tag = other.gameObject.tag;
        if (_tag == "Player")
        {
            Gate_Locked = true;
            other_Gate_Script.Gate_Locked = true;
            Player_Transform.position = new Vector3(Player_Transform.position.x, Player_Transform.position.y, -Player_Transform.position.z);
        }
    }
}
