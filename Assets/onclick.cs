using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onclick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("gaveFood", 0);
        if (PlayerPrefs.GetString("gfPath") != "g2")
        {
            gameObject.active = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            clicked();
        }
    }
    public void clicked()
    {
        if(PlayerPrefs.GetInt("gaveFood") == 1) {
            PlayerPrefs.SetInt("gaveFood", 0);
            GetComponent<RawImage>().color = Color.white;

        }
        else
        {
            PlayerPrefs.SetInt("gaveFood", 1);
            GetComponent<RawImage>().color = Color.black;

        }
    }
}
