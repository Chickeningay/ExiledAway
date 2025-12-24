using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataHolder : MonoBehaviour
{


    private void Start()
    {

        if (GameObject.Find("AI").gameObject.scene.name == "DontDestroyOnLoad") { Destroy(gameObject); }
        DontDestroyOnLoad(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
