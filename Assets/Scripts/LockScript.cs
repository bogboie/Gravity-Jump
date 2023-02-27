using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockScript : MonoBehaviour
{
    public int DimensionNumber;
    public GameObject Button;
    public bool locked;
    private Image self_image;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Dimensions", 0);
        self_image = gameObject.GetComponent<Image>();
        int dim_completed = PlayerPrefs.GetInt("Dimensions");

        if (dim_completed +1 >= DimensionNumber) {
            unlock_button();
        }
        else
        {
            lock_button();
        }
    }
    void lock_button()
    {
        locked = true;
        Button.SetActive(false);
        self_image.enabled = true;

    }
    void unlock_button()
    {
        locked = false;
        Button.SetActive(true);
        self_image.enabled = false;
    }

}
