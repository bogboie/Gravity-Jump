using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedMove : MonoBehaviour
{
    public bool never_stop = false;
    public float Period = 10;
    public float delta_Z = 10;
    private Vector3 Start_Pos;
    private float Start_Z;
    public float time = 0;
    private float passed_time;
    private const float Two_Pi = 2 * Mathf.PI;
    private bool touching;
    // Start is called before the first frame update
    private void kill()
    {
        EventManager.OnRespawn -= Reset;
        EventManager.OnSceneClose -= kill;
    }
    private void Awake()
    {
        EventManager.OnRespawn += Reset;
        EventManager.OnSceneClose += kill;
    }
    void Start()
    {
        touching = false;
        Start_Pos = transform.position;
        Start_Z = Start_Pos.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (touching)
        {
            passed_time += Time.deltaTime;
        }
        Start_Pos.z = Start_Z + delta_Z * Mathf.Sin(Two_Pi * (passed_time) / Period);
        transform.position = Start_Pos;

    }

    private void Reset()
    {
        touching = false;
        passed_time = 0;
    }
    private void OnTriggerEnter(Collider other) {
      if (other.gameObject.tag == "Player") {
        touching = true;
      }
    }
    private void OnTriggerExit(Collider other) {
      if (other.gameObject.tag == "Player" && !never_stop) {
        touching = false;
      }
    }
}
