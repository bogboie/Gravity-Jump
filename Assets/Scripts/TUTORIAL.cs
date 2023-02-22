using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TUTORIAL : MonoBehaviour
{
    [SerializeField]
    private GameObject da_tingy;
    // Start is called before the first frame update
    void Start()
    {
        da_tingy.SetActive(false);
    }

    public void magic()
    {
        da_tingy.SetActive(true);
        gameObject.SetActive(false);
    }
}
