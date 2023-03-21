using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FancyLoading : MonoBehaviour
{
    [SerializeField]
    public Transform HeHeHeHaw;
    [SerializeField]
    private float a = 2.1f;
    [SerializeField]
    private float Land_Every = 4;
    // Start is called before the first frame update
    private float angle(float time)
    {
        float b = -1f;
        float x;
        x = 1f/Land_Every * Mathf.Sin(a * time + a * b) + (a * time + a * b) / Land_Every + Mathf.PI/ Land_Every;
        
        return x * 180f / Mathf.PI;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 euler = new Vector3(0, 0, angle(Time.time));
        HeHeHeHaw.rotation = Quaternion.Euler(euler);
    }
}
