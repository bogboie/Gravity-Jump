using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    private GameObject player;
    private PlayerMovement playerScript;
    private Vector2 screen_pos;

    // Start is called before the first frame update
    void Start()
    {
    player = GameObject.Find("Apple");
    playerScript = player.GetComponent<PlayerMovement>();
    screen_pos = new Vector2(transform.position.x,transform.position.y);
    }

    void OnMouseDown() {
      playerScript.Jump();
    }
    // Update is called once per frame
    private float Dist(Vector2 A, Vector2 B) {
        Vector2 C = A - B;
        return C.magnitude;
    }

    void Update()
    {
      if (Input.touchCount > 0) {
          Touch touch = Input.GetTouch(0);
          if (touch.phase == UnityEngine.TouchPhase.Began) {
              float dist = Dist(touch.position, screen_pos);
              if (dist < 20) {
                  playerScript.Jump();
              }
          }
      }
    }
}
