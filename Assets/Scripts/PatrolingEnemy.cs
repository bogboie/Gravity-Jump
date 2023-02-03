using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PatrolingEnemy : MonoBehaviour
{

enum Direction
{
  Left, Right
}

    // Start is called before the first frame update
    [SerializeField] private Direction direction = Direction.Right;
    public int Fzero = 0;
    public int Threshold;
    private int TwoFzero;
    [SerializeField]
    private float StartingXPos;
    private Rigidbody rb;
    private Vector3 OG_Place;

    public void kms() {
      gameObject.SetActive(false);
    }
    private void kill()
    {
        EventManager.OnRespawn -= respawn;
        EventManager.OnSceneClose -= kill;
    }

    private void Awake()
    {
        EventManager.OnRespawn += respawn;
        EventManager.OnSceneClose += kill;
    }

    void Start()
    {
      OG_Place = transform.position;
        gameObject.SetActive(true);
        TwoFzero = 2 * Fzero;
        StartingXPos = transform.position.z;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0,0,Fzero);
    }
    void SwitchDirection() {
      TwoFzero = -TwoFzero;
      rb.AddForce(0,0,TwoFzero);
    }
    float abs(float x) {
      if (x < 0) {
        return -x;
      } else {
        return x;
      }
    }
    private void ResetVelocity() {
      rb.velocity = Vector3.zero;
      rb.angularVelocity = Vector3.zero;
    }

    void respawn() {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = OG_Place;
        gameObject.SetActive(true);
        rb.AddForce(0,0,Fzero);
    }



    // Update is called once per frame
    void Update()
    {
      if (transform.position.z > StartingXPos + Threshold) {
        ResetVelocity();
        direction = Direction.Left;
      }
      else if  (transform.position.z < StartingXPos) {
        ResetVelocity();
        direction = Direction.Right;
      }
      switch (direction) {

        case Direction.Left:
          rb.velocity = new Vector3(0,0,-1);


          break;
        case Direction.Right:
          rb.velocity = new Vector3(0,0,1);
          break;
      }

    }

    void OnTriggerEnter(Collider other) {
      if (other.gameObject.tag == "Player") {// check if we should either kill player or die
        // then check if the angle between their centers is low enough to kill the Player
        // get enemy Position
        Vector3 playerPos = other.transform.position;
        Vector2 line = new Vector2(transform.position.z-playerPos.z,transform.position.y-playerPos.y);
        double slope = Mathf.Abs(line.y/line.x);
        print(slope);
        if (slope > 1) { // means that the player jumped on "top" of us(enemy) and we are gunnna dy
          kms();
      } else { // means that the player is gunna die HEHEHEHAW
        }
      }
    }
}
