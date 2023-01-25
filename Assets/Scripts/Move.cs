using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float Period = 10;
    public float delta_Z = 10;
    private Vector3 Start_Pos;
    private float Start_Z;
    public float time = 0;
    private const float Two_Pi = 2 * Mathf.PI;
    private void kill()
    {
        EventManager.OnRespawn -= reset;
        EventManager.OnSceneClose -= kill;
    }
    private void reset()
    {
        Start_Pos.z = Start_Z;
        transform.position = Start_Pos;
        
    }
    void Awake()
    {
        EventManager.OnRespawn += reset;
        EventManager.OnSceneClose += kill;
    }
    // Start is called before the first frame update
    void Start()
    {
        // if we want to move from z1'
        Start_Pos = this.transform.position;
        Start_Z = Start_Pos.z;
    }

    // Update is called once per frame
    void Update()
    {
        Start_Pos.z = Start_Z + delta_Z * Mathf.Sin(Two_Pi * (Time.time + time)/ Period);
        this.transform.position = Start_Pos;

       
    }
}
