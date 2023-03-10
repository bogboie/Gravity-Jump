using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Move_Scene : MonoBehaviour
{
    private float Start_Time;
    public float LoadTime = 5;
    public GameObject DotMain;
    public GameObject initialDot;
    public int DotCount = 300;
    private GameObject[] LoadingDots;
    private Vector3[] ScaleChanges;
    public float Biggest_Size = 0.8f;
    public float position_difference = .006f;
    public Vector3 BALLSPEED;
    public int dimension_completed = 0;

    void Start()
    {
        Start_Time = Time.time;
        LoadingDots = new GameObject[DotCount];
        ScaleChanges = new Vector3[DotCount];
        for (int i = 0; i < DotCount; i++)
        {
            LoadingDots[i] = Instantiate(DotMain, initialDot.transform);
            LoadingDots[i].transform.localScale = new Vector3(Biggest_Size, Biggest_Size, Biggest_Size);
            LoadingDots[i].transform.position += new Vector3(0.0f, 0.0f, position_difference * i);
            Vector3 Starting_Scale = BALLSPEED;
            for (int x = 0; x < i * 1000 / DotCount; x++)
            {
                LoadingDots[i].transform.localScale -= Starting_Scale;
                if (LoadingDots[i].transform.localScale.y < 0.1f || LoadingDots[i].transform.localScale.y > Biggest_Size)
                {
                    Starting_Scale = -Starting_Scale;
                }
            }

            ScaleChanges[i] = Starting_Scale;
        }
    }
    // Update is called once per fram
    void Update()
    {
        for (int i = 0; i < DotCount; i++)
        {
            LoadingDots[i].transform.localScale -= ScaleChanges[i];
            if (LoadingDots[i].transform.localScale.y < 0.1f || LoadingDots[i].transform.localScale.y > Biggest_Size)
            {
                ScaleChanges[i] = -ScaleChanges[i];
            }
        }
        if (Time.time - Start_Time > LoadTime)
        {
            PlayerPrefs.SetInt("Dimensions", dimension_completed);
            print("Setting Dimensions Completed to " + dimension_completed.ToString());
            EventManager.GoToLevelSelectScene();


        }

    }
}