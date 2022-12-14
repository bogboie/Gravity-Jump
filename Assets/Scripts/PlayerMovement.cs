using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private GameObject Jump_Button;
    private GameObject left_button;
    private GameObject right_button;
    private GameObject Down;
    private Button left;
    private Button right;
    [SerializeField]
    private Rigidbody rb;
    public Camera CameraObject;
    private Transform ownTransform;
    [SerializeField]
    private bool canJump = false;
    private Vector3 cam_offset = new Vector3(10, 0, 0);
    private Vector3 hide_button = new Vector3(0, 1, 1);
    private Vector3 show_button = new Vector3(0.3f, 0.3f, 0.3f);
    private Transform starting_pos;
    private GameObject gateleft;
    private GameObject gateright;
    private Collider gateColliderleft;
    private Collider gateColliderright;
    private Vector2 Jump_Button_Pos;
    private Touch touch;
    private GameObject[] objects;
    public AudioSource JumpAudio;
    public AudioSource pushSource;
    public AudioSource woodSource;
    private SpecialEnemy[] s_enemies;

    private void hide_buttons()
    {
        left_button.transform.localScale = hide_button;
        right_button.transform.localScale = hide_button;
        left.interactable = false;
        right.interactable = false;
        //pushSource.Play();
    }
    private void show_buttons()
    {
        left_button.transform.localScale = show_button;
        right_button.transform.localScale = show_button;
        left.interactable = true;
        right.interactable = true;
    }
    public void push_left()
    {
        rb.AddForce(0, 0, -1200);
        hide_buttons();
    }
    public void push_right()
    {
        rb.AddForce(0, 0, 1200);
        hide_buttons();
    }
    public void kill_player()
    {
        ownTransform.position = starting_pos.position;
        rb.velocity = new Vector3(0, 0, 0);
        rb.angularVelocity = new Vector3(0, 0, 0);
        gateColliderleft.enabled = true;
        gateColliderright.enabled = true;

        foreach (GameObject obj in objects) {
          ActivatedMove script = obj.GetComponent<ActivatedMove>();
          script.Reset();
        }
        foreach(SpecialEnemy script in s_enemies) {
          script.Reset();
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        //get the following objects to be able to reference later in game
        Jump_Button =  GameObject.Find("Thy Jump Squisher Dos!"); // The Jump Button
        starting_pos = GameObject.Find("Starting position").transform;
        left_button  = GameObject.Find("Left"); // The Push Left Button
        right_button = GameObject.Find("Right"); // The Push Right Button
        left = left_button.GetComponent<Button>();
        right = right_button.GetComponent<Button>();
        Down = Jump_Button.transform.GetChild(0).gameObject;
        gateleft = GameObject.Find("Left Gate Activator");
        gateright = GameObject.Find("Right Gate Activator");
        objects = GameObject.FindGameObjectsWithTag("Activated Platform"); // All Trigger Activated Moving Platforms
        s_enemies = FindObjectsOfType(typeof(SpecialEnemy)) as SpecialEnemy[];
        gateColliderleft = gateleft.GetComponent<BoxCollider>(); // The Left Gate Collider
        gateColliderright = gateright.GetComponent<BoxCollider>(); // The Right Gate Collider
        rb = GetComponent<Rigidbody>(); // Its own Rigidbody
        ownTransform = GetComponent<Transform>(); // Its own Transform
        ownTransform.position = starting_pos.position; // Its own Starting Position
        hide_buttons();
        Jump_Button_Pos = new Vector2(Jump_Button.transform.position.x, Jump_Button.transform.position.z);
        //woodSource.Play();
    }

    private void LateUpdate()
    {
        CameraObject.transform.position = this.transform.position + cam_offset;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            canJump = true;
        }
        else if (other.gameObject.tag == "Player Killer")
        {
            kill_player();
        }
        else if (other.gameObject.tag == "Choice")
        {
            show_buttons();
        } else if (other.gameObject.tag == "Enemy") {
          // then check if the angle between their centers is low enough to kill the Player
          // get enemy Position
          Vector3 enemyPos = other.transform.position;
          Vector2 line = new Vector2(enemyPos.z-transform.position.z,enemyPos.y-transform.position.y);
          double slope = Mathf.Abs(line.y/line.x);
          if (slope > 2) { // means that we jumped on "top" of the enemy so we dont die !! (yay)
        } else { // means that we are gunna die
              kill_player(); //L
              print('L');
          }

        }
    }
    private float Dist(Vector2 A, Vector2 B)
    {
        Vector2 C = A - B;
        return Mathf.Sqrt(C.x * C.x + C.y * C.y);
    }

    public void Jump()
    {
        if (canJump) {
            rb.AddForce(0, 2000, 0);
            canJump = false;
            //JumpAudio.Play();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            canJump = false;
        }
        else if (other.gameObject.tag == "Choice")
        {
            left_button.transform.localScale = hide_button;
            right_button.transform.localScale = hide_button;
            left.interactable = false;
            right.interactable = false;
        }
    }
    public void Next_Level() {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    private void Update()
    {
        if (canJump) {
          Down.SetActive(false);
        } else {
          Down.SetActive(true);
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == UnityEngine.TouchPhase.Began)
            {
                float dist = Dist(touch.position, Jump_Button_Pos);
                if (dist < 60)
                {
                    Jump();
                }
            }
        }
    }
}
