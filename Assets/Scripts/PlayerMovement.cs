using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public Button left_button;
    public Button right_button;
    private Rigidbody rb;
    public Camera CameraObject;
    private Transform ownTransform;
    public bool canJump = false;
    private Vector3 cam_offset = new Vector3(10, 0, 0);
    private Vector3 hide_button = new Vector3(0, 1, 1);
    public void push_left()
    {
        rb.AddForce(0, 0, -250);
        left_button.transform.localScale = hide_button;
        right_button.transform.localScale = hide_button;
        left_button.interactable = false;
        right_button.interactable = false;
    }
    public void push_right()
    {
        rb.AddForce(0, 0, 250);
        left_button.transform.localScale = hide_button;
        right_button.transform.localScale = hide_button;
        left_button.interactable = false;
        right_button.interactable = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ownTransform = GetComponent<Transform>();
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
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            canJump = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && canJump) {
            rb.AddForce(0,500,0);
        }
    }
}
