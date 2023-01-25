using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSpike : MonoBehaviour
{
  public float deltaY = 2;
  public float Period = 2;
  private Transform ownTransform;
  private float starting_Y;
    // Start is called before the first frame update
    private void reset()
    {

        transform.position = ownTransform.position;
    }
    private void kill()
    {
        EventManager.OnRespawn -= reset;
        EventManager.OnSceneClose -= kill;
        
    }
    private void Awake()
    {
        EventManager.OnRespawn += reset;
        EventManager.OnSceneClose += kill;
    }
    void Start()
    {
      ownTransform = this.transform;
      starting_Y = ownTransform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x,starting_Y + deltaY * Mathf.Sin(Time.time/Period),transform.position.z);
    }
}
