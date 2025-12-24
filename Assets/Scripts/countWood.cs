using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class countWood : MonoBehaviour
{
    public int woodCount;
    public GameObject dataHolder;
    // Start is called before the first frame update
    void Start()
    {
        dataHolder = GameObject.Find("AI");
        woodCount = PlayerPrefs.GetInt("WoodAmount");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("WoodAmount", woodCount);


        gameObject.GetComponent<TMP_Text>().text = woodCount.ToString();
    }
}
