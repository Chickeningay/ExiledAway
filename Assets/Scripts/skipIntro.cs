using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skipIntro : MonoBehaviour
{
    bool first;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("WoodAmount", 10);
        PlayerPrefs.SetInt("FoodAmount", 10);
        PlayerPrefs.SetString("gfPath", "g1");
        PlayerPrefs.SetString("fatherPath", "f1");
        PlayerPrefs.SetInt("day", 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!first)
            {
                transform.GetChild(0).gameObject.active = false;
                transform.GetChild(1).gameObject.active = true;
                first = true;
            }
            else
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
