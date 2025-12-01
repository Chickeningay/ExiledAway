using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class countFood : MonoBehaviour
{
    public int foodCount;
    public GameObject dataHolder;
    // Start is called before the first frame update
    void Start()
    {
        dataHolder = GameObject.Find("AI");
    }

    // Update is called once per frame
    void Update()
    {
        dataHolder.GetComponent<dataHolder>().foodAmount = foodCount;

        gameObject.GetComponent<TMP_Text>().text = foodCount.ToString();
    }
}
