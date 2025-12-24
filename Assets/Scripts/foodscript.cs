using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodscript : MonoBehaviour
{
    public int amount;
    public GameObject dataHolder;
    public List<GameObject> children = new List<GameObject>();
    void Start()
    {
        dataHolder = GameObject.Find("AI");
        foreach (Transform child in transform.GetComponentsInChildren<Transform>())
        {
            if (child.gameObject != gameObject)
            {
                children.Add(child.gameObject);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var child in children) { child.SetActive(false); }

        amount = PlayerPrefs.GetInt("FoodAmount");
        int kids = 0;
        switch (amount)
        {
            case > 5:
                kids = 5;
                break;
            case > 4:
                kids = 4;
                break;
            case > 3:
                kids = 3;
                break;
            case > 2:
                kids = 2;
                break;
            case > 1:
                kids = 1;
                break;
        }
        for (int x = 0; x < kids; x++)
        {
            children[x].SetActive(true);

        }
    }
}
