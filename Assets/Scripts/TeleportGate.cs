using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportGate : MonoBehaviour
{
    public GameObject gateleft;
    public GameObject gateright;
    private Collider gateColliderleft;
    private Collider gateColliderright;

    private void Awake()
    {
        gateColliderleft = gateleft.GetComponent<BoxCollider>();
    }
    void OnTriggerExit(Collider other)
    {
        tag = other.gameObject.tag;
        if (tag == "Player")
        {
            gateColliderleft.enabled = true;
            gateColliderright.enabled = true;
        }
    }
}
