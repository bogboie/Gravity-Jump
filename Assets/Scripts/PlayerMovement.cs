using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public GameObject thingy;
    public Button left_button;
    public Button right_button;
    private Rigidbody rb;
    public Camera CameraObject;
    private Transform ownTransform;
    public bool canJump = false;
    private Vector3 cam_offset = new Vector3(10, 0, 0);
    private Vector3 hide_button = new Vector3(0, 1, 1);
    private Vector3 show_button = new Vector3(0.3f, 0.3f, 0.3f);
    public Transform starting_pos;
    public GameObject gateleft;
    public GameObject gateright;
    private Collider gateColliderleft;
    private Collider gateColliderright;
    public Transform Jump_Button;
    private Vector2 Jump_Button_Pos;
    private Touch touch;
    private GameObject[] objects;
    public AudioSource audioSource;
    public AudioSource pushSource;
    public AudioSource woodSource;

    private void hide_buttons()
    {
        left_button.transform.localScale = hide_button;
        right_button.transform.localScale = hide_button;
        left_button.interactable = false;
        right_button.interactable = false;
        pushSource.Play();
    }
    private void show_buttons()
    {
        left_button.transform.localScale = show_button;
        right_button.transform.localScale = show_button;
        left_button.interactable = true;
        right_button.interactable = true;
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

    }

    // Start is called before the first frame update
    void Start()
    {
        objects = GameObject.FindGameObjectsWithTag("Activated Platform");
        gateColliderleft = gateleft.GetComponent<BoxCollider>();
        gateColliderright = gateright.GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        ownTransform = GetComponent<Transform>();
        ownTransform.position = starting_pos.position;
        hide_buttons();
        Jump_Button_Pos = new Vector2(Jump_Button.position.x, Jump_Button.position.z);
        woodSource.Play();
    }

    private void LateUpdate()
    {
        CameraObject.transform.position = ownTransform.position + cam_offset;
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
        }
    }
    private float Dist(Vector2 A, Vector2 B)
    {
        Vector2 C = A - B;
        return Mathf.Sqrt(C.x * C.x + C.y * C.y);
    }

    public void Jump()
    {
        if (canJump)
        {
            rb.AddForce(0, 2000, 0);
            canJump = false;
            audioSource.Play();
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
            left_button.interactable = false;
            right_button.interactable = false;
        }
    }
    public void Next_Level() {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    private void Update()
    {
        if (canJump) {
          thingy.SetActive(false);
        } else {
          thingy.SetActive(true);
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == UnityEngine.TouchPhase.Began)
            {
                float dist = Dist(touch.position, Jump_Button_Pos);
                if (dist > 100)
                {
                    Jump();
                }
            }
        }
    }
}
