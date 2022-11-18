using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedMove : MonoBehaviour
{

    public GameObject Player;
    public Rigidbody Player_Rigidbody;
    public bool never_stop = false;
    private float zed;
    public float Period = 10;
    public float delta_Z = 10;
    private Vector3 Start_Pos;
    private float Start_Z;
    public float time = 0;
    private float passed_time;
    private bool touched;
    private const float Two_Pi = 2 * Mathf.PI;
    private bool touching;
    // Start is called before the first frame update
    void Start()
    {
        Start_Pos = this.transform.position;
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

    public void Reset()
    {
        touching = false;
        passed_time = 0;
    }
    private void OnTriggerEnter(Collider other) {
      if (other.gameObject == Player) {
        touching = true;
        //zed = Player_Rigidbody.velocity.z;
        //Player_Rigidbody.velocity = Vector3.zero;
        //Player.transform.SetParent(transform);
      }
    }
    private void OnTriggerExit(Collider other) {
      if (other.gameObject == Player && !never_stop) {
        touching = false;
        //Player.transform.SetParent(null);
        //Player_Rigidbody.velocity.Set(Player_Rigidbody.velocity.x,Player_Rigidbody.velocity.y,zed);
      }
    }
}
