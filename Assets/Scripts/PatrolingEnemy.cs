using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolingEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int Fzero = 0;
    public int Threshold;
    private int TwoFzero;
    [SerializeField]
    private float StartingXPos;
    private Rigidbody rb;

    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
      if (abs(transform.position.z - StartingXPos) >= Threshold) {
        SwitchDirection();
      }
    }
}
