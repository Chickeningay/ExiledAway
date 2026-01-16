using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapSubScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0, 2) == 1) 
        {
            transform.GetChild(0).gameObject.active = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
