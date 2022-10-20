using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedMove : MonoBehaviour
{
    public float Period = 10;
    public float delta_Z = 10;
    private Vector3 Start_Pos;
    private float Start_Z;
    public float time = 0;
    private float passed_time;
    private bool touched;
    private const float Two_Pi = 2 * Mathf.PI;
    // Start is called before the first frame update
    void Start()
    {
        Start_Pos = this.transform.position;
        Start_Z = Start_Pos.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (!touched)
        {
            passed_time = Time.time;
        }
        Start_Pos.z = Start_Z + delta_Z * Mathf.Sin(Two_Pi * (Time.time-passed_time) / Period);
        this.transform.position = Start_Pos;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touched = true;
        }
    }
    public void Reset()
    {
        touched = false;
    }
}
