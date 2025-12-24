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
        foodCount = PlayerPrefs.GetInt("FoodAmount");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("FoodAmount", foodCount);

        gameObject.GetComponent<TMP_Text>().text = foodCount.ToString();
    }
}
