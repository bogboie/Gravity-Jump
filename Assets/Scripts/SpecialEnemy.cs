using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemy : MonoBehaviour
{
    private GameObject player;
    public double Vision;
    public double Speed;
    private double dist_to_player;
    private Rigidbody rb;
    private Vector3 Starting_pos;


    public void Reset() {
      // go back to starting_pos
      transform.position = Starting_pos;
      // stop Moving
      rb.velocity = Vector3.zero;
      rb.angularVelocity = Vector3.zero;
    }

    public void kms() {
      gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        Starting_pos = transform.position;
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
    }
    void Follow_Player() {
      if (player.transform.position.z < transform.position.z) {
         //go to the left

         rb.AddForce(0,0,-1);
      } else if (player.transform.position.z > transform.position.z) {
        //go to the right

        rb.AddForce(0,0,1);

      }
    }

    void OnTriggerEnter(Collider other) {
      if (other.gameObject.tag == "Player") {// check if we should either kill player or die
        // then check if the slope between their centers is low enough to kill the Player
        // get enemy Position
        Vector3 playerPos = other.transform.position;
        Vector2 line = new Vector2(transform.position.z-playerPos.z,transform.position.y-playerPos.y);
        double slope = Mathf.Abs(line.y/line.x);
        print(slope);
        if (slope > 1) { // means that the player jumped on "top" of us(enemy) and we are gunnna dy
          kms();
        } else { // means that the player is gunna die HEHEHEHAW }
        }
      }
    }

    // Update is called once per frame
    void Update()
    {
      dist_to_player = (player.transform.position-transform.position).magnitude;
      if (dist_to_player < Vision) {
        Follow_Player();
      }
    }
}
