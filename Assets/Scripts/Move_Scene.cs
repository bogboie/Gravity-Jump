using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Move_Scene : MonoBehaviour
{
  public float LoadTime = 5;
  public GameObject DotMain;
  public GameObject initialDot;
  public int DotCount;
  private GameObject[] LoadingDots ;
  private Vector3 ScaleChange = new Vector3(.01f,.01f,.01f);

  void Start()
  {
    LoadingDots = new GameObject[DotCount];
    for (int i = 0; i < DotCount; i++)
    {
      Debug.Log(i);
      LoadingDots[i] = Instantiate(DotMain, initialDot.transform);
      LoadingDots[i].transform.position += new Vector3(0.0f,0.0f,1.0f*i);
    }
  }
    // Update is called once per fram
    void Update()
    {

      for (int i = 0; i < DotCount; i++)
      {
        LoadingDots[i].transform.localScale -= ScaleChange;
      }
        if (Time.time > LoadTime) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
      if (LoadingDots[0].transform.localScale.y < 0.1f || LoadingDots[0].transform.localScale.y > 1.0f)
      {
        ScaleChange = -ScaleChange;
      }
    }
/*void Update () {
    nasru -= Time.deltaTime;
    if(nasru <= 0)
    {
        nasru = 3;
        GameObject go = GameObject.Instantiate(enemyMake);
        go.transform.localScale = transform.position;
    }*/
}
