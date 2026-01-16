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
