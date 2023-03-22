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
    [SerializeField]
    private double maxvelocity;
    public AudioSource EnemyDeath;
    public AudioSource PlayerDeath;
    public AudioSource EnemyMove;
    public AudioSource EnemyAlert;

    public void Reset() {
      // go back to starting_pos
      transform.position = Starting_pos;
      // stop Moving
      rb.velocity = Vector3.zero;
      rb.angularVelocity = Vector3.zero;
      gameObject.SetActive(true);
    }

    public void kms() {
      gameObject.SetActive(false);
    }

    private void kill()
    {
        EventManager.OnRespawn -= Reset;
        EventManager.OnSceneClose -= kill;
    }
    public void Awake()
    {
        EventManager.OnRespawn += Reset;
        EventManager.OnSceneClose += kill;
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


        if (rb.velocity.z > -maxvelocity) {
           rb.AddForce(0,0,-1);
        }
      } else if (player.transform.position.z > transform.position.z) {
        //go to the right
        if (rb.velocity.z < maxvelocity) {

        rb.AddForce(0,0,1);
        }
      }
    }

    void OnTriggerEnter(Collider other) {
      if (other.gameObject.tag == "Player") {// check if we should either kill player or die
        // then check if the slope between their centers is low enough to kill the Player
        // get enemy Position
        Vector3 playerPos = other.transform.position;
        Vector2 line = new Vector2(transform.position.z-playerPos.z,transform.position.y-playerPos.y);
        if (line.y > 0) {
          // we are abote the player
          // so we do not die no matter what and dont need to calculate the slope
          return;
        }
        double slope = Mathf.Abs(line.y/line.x);

        print(slope);
        if (slope > 1) { // means that the player jumped on "top" of us(enemy) and we are gunnna dy
          kms();
        AudioFX.Play(EnemyDeath);
        } else { // means that the player is gunna die HEHEHEHAW }
        AudioFX.Play(PlayerDeath);
        }
      }
    }

    // Update is called once per frame
    void Update()
    {
      dist_to_player = (player.transform.position-transform.position).magnitude;
      if (dist_to_player < Vision) {
      AudioFX.Play(EnemyAlert);
        Follow_Player();
      AudioFX.Play(EnemyMove);
      }
    }
}
