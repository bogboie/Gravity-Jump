using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpicCameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Player;
    private float smoothTime = .3f;
    private Vector3 velocity = Vector3.zero;
    private Vector3 cam_offset = new Vector3(10, 0, 0);

    void Start()
    {
        Player = GameObject.Find("Apple");
        this.transform.position = Player.transform.position + cam_offset;

    }


    private void FixedUpdate()
    {
        // Define a target position above and behind the target transform
        

        Vector3 targetPosition = Player.transform.position + cam_offset;
        
        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

}
