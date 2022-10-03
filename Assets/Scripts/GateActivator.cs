using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateActivator : MonoBehaviour
{
    public GameObject Left_Gate;
    public GameObject Right_Gate;
    private TeleportGate Left_Gate_Script;
    private TeleportGate Right_Gate_Script;
    private string _tag;
    // Start is called before the first frame update
    void Awake()
    {
        Left_Gate_Script = Left_Gate.GetComponent<TeleportGate>();
        Right_Gate_Script = Right_Gate.GetComponent<TeleportGate>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _tag = other.gameObject.tag;
        if (_tag == "Player")
        {
            Left_Gate_Script.Gate_Locked = false;
            Right_Gate_Script.Gate_Locked = false;

        }
    }
}
